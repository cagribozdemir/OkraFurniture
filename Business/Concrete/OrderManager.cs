﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        IProductService _productService;
        IProductColorService _productColorService;
        IFootService _footService;
        IFootColorService _footColorService;
        IFabricService _fabricService;
        IProformaService _proformaService;
        ICategoryService _categoryService;

        public OrderManager(IOrderDal orderDal, IProductService productService, IProductColorService productColorService, 
            IFootColorService footColorService, IFabricService fabricService, IFootService footService, IProformaService proformaService,
            ICategoryService categoryService)
        {
            _orderDal = orderDal;
            _productService = productService;
            _productColorService = productColorService;
            _footColorService = footColorService;
            _fabricService = fabricService;
            _footService = footService;
            _proformaService = proformaService;
            _categoryService = categoryService;
        }

        public IResult Add(CreateOrderDto createOrderDto)
        {
            decimal totalPrice = CalculateTotalPrice(createOrderDto);
            Order order = MapCreateDtoToOrder(createOrderDto, totalPrice);

            _orderDal.Add(order);
            _proformaService.UpdateTotalPrice(order.ProformaId, totalPrice);
            
            return new SuccessResult(Messages.OrderAdded);
        }

        public void Delete(int id)
        {
            Order order = _orderDal.Get(o => o.Id == id);
            _proformaService.UpdateTotalPrice(order.ProformaId, order.TotalPrice * -1);
            _orderDal.Delete(order);
        }

        public List<ResultOrderDto> GetAll()
        {
            return MapOrderToResultDto(_orderDal.GetAll());
        }

        public List<ResultOrderDto> GetByProformaId(int proformmaId)
        {
            return MapOrderToResultDto(_orderDal.GetAll(o => o.ProformaId == proformmaId));
        }

        public Order GetById(int id)
        {
            return _orderDal.Get(o => o.Id == id);
        }

        public IResult Update(Order order)
        {
            decimal proformaTotalPrice = _orderDal.Get(o => o.Id == order.Id).TotalPrice * -1;
            decimal newTotalPrice = order.Price * order.Amount * (100 - order.Discount) / 100;
            order.Piece = order.Amount * _productService.GetById(order.ProductId).Piece;
            order.TotalPrice = newTotalPrice;

            proformaTotalPrice += newTotalPrice;
            _proformaService.UpdateTotalPrice(order.ProformaId, proformaTotalPrice);
            _orderDal.Update(order);

            return new SuccessResult(Messages.OrderUpdated);
        }

        public List<ResultOrderDto> GetProductionsByFootId(int footId)
        {
            var orders = _orderDal.GetAll(o => o.FootId == footId && o.WeldProcess == 1);

            Dictionary<int?, int> totalAmounts = new Dictionary<int?, int>();

            foreach (var order in orders)
            {
                if (totalAmounts.ContainsKey(order.FootColorId))
                {
                    totalAmounts[order.FootColorId] += order.Amount;
                }
                else
                {
                    totalAmounts[order.FootColorId] = order.Amount;
                }
            }

            List<ResultOrderDto> resultDto = new List<ResultOrderDto>();
            foreach (var pair in totalAmounts)
            {
                resultDto.Add(new ResultOrderDto
                {
                    FootColorName = _footColorService.GetById(pair.Key).Name,
                    Amount = pair.Value
                });
            }

            return resultDto;
        }

        public List<ResultOrderDto> GetProductionsByProductId(int productId, int production)
        {
            return MapOrderToResultDto(_orderDal.GetAll(o => o.ProductId == productId && o.Production == production));
        }

        public void UpdateProcess(int id, int process)
        {
            Order order = _orderDal.Get(o => o.Id == id);
            order.Production = process;
            _orderDal.Update(order);
            
            if (process == 4)
            {
                _proformaService.UpdateProcess(order.ProformaId, 2);

                var orders = GetByProformaId(order.ProformaId);
                foreach (var result in orders)
                {
                    if (orders.All(o => o.Process == 4))
                    {
                        _proformaService.UpdateProcess(order.ProformaId, 3);
                    }
                }
            }
        }

        private decimal CalculateTotalPrice(CreateOrderDto createOrderDto)
        {
            return createOrderDto.Amount * createOrderDto.Price;
        }

        private Order MapCreateDtoToOrder(CreateOrderDto dto, decimal totalPrice)
        {
            int production = ProductionCalculater(dto.ProductId);
            return new Order
            {
                ProformaId = dto.ProformaId,
                ProductId = dto.ProductId,
                ProductColorId = dto.ProductColorId,
                Amount = dto.Amount,
                Piece = dto.Amount * _productService.GetById(dto.ProductId).Piece,
                Discount = dto.Discount,
                Price = dto.Price,
                Description = dto.Description,
                TotalPrice = totalPrice,
                Status = true,
                FabricId = dto.FabricId,
                FootId = dto.FootId,
                FootColorId = dto.FootColorId,
                Production = production,
                WeldProcess = 1
            };
        }

        private List<ResultOrderDto> MapOrderToResultDto(List<Order> orders)
        {
            List<ResultOrderDto> resultOrderDtos = new List<ResultOrderDto>();
            foreach (var order in orders)
            {
                ResultOrderDto resultOrderDto = new ResultOrderDto();
                var categoryName = _categoryService.GetById(_productService.GetById(order.ProductId).CategoryId).Name;

                resultOrderDto.Id = order.Id;
                resultOrderDto.Amount = order.Amount;
                resultOrderDto.CategoryName = categoryName;
                resultOrderDto.ProductCode = _productService.GetById(order.ProductId).Code;
                resultOrderDto.ProductName = _productService.GetById(order.ProductId).Name;
                resultOrderDto.ProductColorName = _productColorService.GetById(order.ProductColorId).Name;
                resultOrderDto.Piece = order.Piece;
                resultOrderDto.Discount = order.Discount;
                resultOrderDto.Price = order.Price;
                resultOrderDto.TotalPrice = order.TotalPrice;

                #region Fabric, Footcolor, Foot
                if (categoryName == "Masa")
                {
                    resultOrderDto.FabricName = "---";
                    resultOrderDto.FootColorName = _footColorService.GetById(order.FootColorId).Name;
                    resultOrderDto.FootName = _footService.GetById(order.FootId).Name;
                }
                else if (categoryName == "Tv Ünitesi" || categoryName == "Orta Sehpa" || categoryName == "Ayna")
                {
                    resultOrderDto.FabricName = "---";
                    resultOrderDto.FootColorName = "---";
                    resultOrderDto.FootName = "---";
                }
                else
                {
                    resultOrderDto.FabricName = _fabricService.GetById(order.FabricId).Name;
                    resultOrderDto.FootColorName = _footColorService.GetById(order.FootColorId).Name;
                    resultOrderDto.FootName = _footService.GetById(order.FootId).Name;
                }
                #endregion

                #region Process
                if (categoryName == "Masa")
                {
                    switch (order.Production)
                    {
                        case 1:
                            resultOrderDto.ProductionName = "CNC Aşamasında";
                            break;
                        case 2:
                            resultOrderDto.ProductionName = "Boyahane Aşamasında";
                            break;
                        case 3:
                            resultOrderDto.ProductionName = "Mobilyahane Aşamasında";
                            break;
                        case 4:
                            resultOrderDto.ProductionName = "Üretim Tamamlandı";
                            break;
                        default:
                            break;
                    }

                }
                else if (categoryName == "Sandalye")
                {
                    switch (order.Production)
                    {
                        case 1:
                            resultOrderDto.ProductionName = "Kaputhane Aşamasında";
                            break;
                        case 2:
                            resultOrderDto.ProductionName = "Terzihane Aşamasında";
                            break;
                        case 3:
                            resultOrderDto.ProductionName = "Döşemehane Aşamasında";
                            break;
                        case 4:
                            resultOrderDto.ProductionName = "Üretim Tamamlandı";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    resultOrderDto.ProductionName = "-----";
                }
                #endregion

                resultOrderDto.Process = order.Production;
                resultOrderDto.Description = order.Description;
                resultOrderDto.CompanyName = _proformaService.GetById(order.ProformaId).CompanyName;
                resultOrderDtos.Add(resultOrderDto);
            }
            return resultOrderDtos;
        }

        private int ProductionCalculater(int productId)
        {
            var product = _productService.GetById(productId);
            var category = _categoryService.GetById(product.CategoryId);
            if (category.Name == "Sandalye" && product.IsKaputhane == false)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}
