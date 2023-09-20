using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Order;
using System;
using System.Collections.Generic;
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
        IProductionService _productionService;

        public OrderManager(IOrderDal orderDal, IProductService productService, IProductColorService productColorService, 
            IFootColorService footColorService, IFabricService fabricService, IFootService footService, IProformaService proformaService,
            ICategoryService categoryService, IProductionService productionService)
        {
            _orderDal = orderDal;
            _productService = productService;
            _productColorService = productColorService;
            _footColorService = footColorService;
            _fabricService = fabricService;
            _footService = footService;
            _proformaService = proformaService;
            _categoryService = categoryService;
            _productionService = productionService;
        }

        public IResult Add(CreateOrderDto createOrderDto)
        {
            decimal totalPrice = CalculateTotalPrice(createOrderDto);
            Order order = MapDtoToOrder(createOrderDto, totalPrice);

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
            List<ResultOrderDto> resultOrderDtos = new List<ResultOrderDto>();
            var orders = _orderDal.GetAll();

            foreach (var order in orders)
            {
                ResultOrderDto resultOrderDto = new ResultOrderDto();
                resultOrderDto.Id = order.Id;
                resultOrderDto.Amount = order.Amount;
                resultOrderDto.CategoryName = _categoryService.GetById(_productService.GetById(order.ProductId).CategoryId).Name;
                resultOrderDto.ProductCode = _productService.GetById(order.ProductId).Code;
                resultOrderDto.ProductName = _productService.GetById(order.ProductId).Name;
                resultOrderDto.ProductColorName = _productColorService.GetById(order.ProductColorId).Name;
                resultOrderDto.Piece = order.Piece;
                resultOrderDto.Discount = order.Discount;
                resultOrderDto.Price = order.Price;
                resultOrderDto.TotalPrice = order.TotalPrice;
                resultOrderDto.ProductionName = _productionService.GetById(order.ProductionId).Name;

                resultOrderDto.FabricName = _fabricService.GetById(order.FabricId).Name;
                resultOrderDto.FootColorName = _footColorService.GetById(order.FootColorId).Name;
                resultOrderDto.FootName = _footService.GetById(order.FootId).Name;

                resultOrderDto.Description = order.Description;

                resultOrderDtos.Add(resultOrderDto);
            }
            return resultOrderDtos;
        }

        public List<ResultOrderDto> GetByProformaId(int proformmaId)
        {
            List<ResultOrderDto> resultOrderDtos = new List<ResultOrderDto>();
            var orders = _orderDal.GetAll(o => o.ProformaId == proformmaId);

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
                resultOrderDto.ProductionName = _productionService.GetById(order.ProductionId).Name;
                resultOrderDto.Piece = order.Piece;
                resultOrderDto.Discount = order.Discount;
                resultOrderDto.Price = order.Price;
                resultOrderDto.TotalPrice = order.TotalPrice;
                if (categoryName == "Masa")
                {
                    resultOrderDto.FabricName = "---";
                    resultOrderDto.FootColorName = _footColorService.GetById(order.FootColorId).Name;
                    resultOrderDto.FootName = "---";
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

                resultOrderDto.Description = order.Description;

                resultOrderDtos.Add(resultOrderDto);
            }
            return resultOrderDtos;
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

        private Order MapDtoToOrder(CreateOrderDto dto, decimal totalPrice)
        {
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
                ProductionId = 1
            };
        }

        private decimal CalculateTotalPrice(CreateOrderDto createOrderDto)
        {
            return createOrderDto.Amount * createOrderDto.Price;
        }
    }
}
