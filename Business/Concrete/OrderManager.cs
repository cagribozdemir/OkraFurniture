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
            proforma.Id =1;

            order.Amount = createOrderDto.Amount;
            order.Discount = createOrderDto.Discount;
            order.Piece = 26;
            order.Price = createOrderDto.Price;
            order.TotalPrice = 582;
            order.Product = product;
            order.ProductColor = productColor;
            order.Fabric = fabric;
            order.FootColor = footColor;
            order.Proforma = proforma;
            order.Status = true;

            _orderDal.Add(order);
            
            //return new SuccessResult(Messages.OrderAdded);
        }

        public void Delete(int id)
        {
            Order order = _orderDal.Get(o => o.Id == id);
            _orderDal.Delete(order);
            //return new SuccessResult(Messages.OrderDeleted);
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
            //return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.OrderListed);
        }

        public Order GetById(int id)
        {
            return _orderDal.Get(c => c.Id == id);
            //return new SuccessDataResult<Order>(_orderDal.Get(c => c.Id == id));
        }

        public void Update(Order order)
        {
            order.ProformaId = 1;
            order.Piece = 26;
            order.TotalPrice = 582;
            _orderDal.Update(order);
            
            //return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
