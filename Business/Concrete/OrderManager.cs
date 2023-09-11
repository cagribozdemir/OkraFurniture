using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.Order;
using Entity.DTOs.Product;
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
        IFootColorService _footColorService;
        IFabricService _fabricService;
        IProformaService _proformaService;

        public OrderManager(IOrderDal orderDal, IProductService productService, IProductColorService productColorService, 
            IFootColorService footColorService, IFabricService fabricService)
        {
            _orderDal = orderDal;
            _productService = productService;
            _productColorService = productColorService;
            _footColorService = footColorService;
            _fabricService = fabricService;
        }

        public void Add(CreateOrderDto createOrderDto)
        {
            Order order = new Order();
            Product product = new Product();
            ProductColor productColor = new ProductColor();
            Fabric fabric = new Fabric();
            FootColor footColor = new FootColor();
            Proforma proforma = new Proforma();

            product.Id = createOrderDto.ProductId;
            productColor.Id = createOrderDto.ProductColorId;
            fabric.Id = createOrderDto.FabricId;
            footColor.Id = createOrderDto.FootColorId;
            proforma.Id = createOrderDto.ProformaId;

            order.Amount = createOrderDto.Amount;
            order.Discount = createOrderDto.Discount;
            order.Piece = createOrderDto.Amount*4*4; //Hesap
            order.Price = createOrderDto.Price;
            order.TotalPrice = createOrderDto.Price * createOrderDto.Amount * (100 - createOrderDto.Discount) / 100; 
            order.Product = product;
            order.ProductColor = productColor;
            order.Fabric = fabric;
            order.FootColor = footColor;
            order.Proforma = proforma;
            order.Status = true;

            _orderDal.Add(order);
        }

        public void Delete(int id)
        {
            Order order = _orderDal.Get(o => o.Id == id);
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
                resultOrderDto.ProductCode = _productService.GetById(order.ProductId).Code;
                resultOrderDto.ProductName = _productService.GetById(order.ProductId).Name;
                resultOrderDto.FabricName = _fabricService.GetById(order.FabricId).Name;
                resultOrderDto.ProductColorName = _productColorService.GetById(order.ProductColorId).Name;
                resultOrderDto.FootColorName = _footColorService.GetById(order.FootColorId).Name;
                resultOrderDto.Piece = order.Piece;
                resultOrderDto.Discount = order.Discount;
                resultOrderDto.Price = order.Price;
                resultOrderDto.TotalPrice = order.TotalPrice;

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

                resultOrderDto.Id = order.Id;
                resultOrderDto.Amount = order.Amount;
                resultOrderDto.ProductCode = _productService.GetById(order.ProductId).Code;
                resultOrderDto.ProductName = _productService.GetById(order.ProductId).Name;
                resultOrderDto.FabricName = _fabricService.GetById(order.FabricId).Name;
                resultOrderDto.ProductColorName = _productColorService.GetById(order.ProductColorId).Name;
                resultOrderDto.FootColorName = _footColorService.GetById(order.FootColorId).Name;
                resultOrderDto.Piece = order.Piece;
                resultOrderDto.Discount = order.Discount;
                resultOrderDto.Price = order.Price;
                resultOrderDto.TotalPrice = order.TotalPrice;

                resultOrderDtos.Add(resultOrderDto);
            }
            return resultOrderDtos;
        }

        public Order GetById(int id)
        {
            return _orderDal.Get(o => o.Id == id);
        }

        public void Update(Order order)
        {
            order.Piece = order.Amount * 4 * 4;
            order.TotalPrice = order.Price * order.Amount * (100 - order.Discount) / 100;
            _orderDal.Update(order);
        }
    }
}
