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

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public void Add(CreateOrderDto createOrderDto)
        {
            Order order = new Order();
            Product product = new Product();
            ProductColor productColor = new ProductColor();
            Fabric fabric = new Fabric();
            FabricColor fabricColor = new FabricColor();
            Foot foot = new Foot();
            FootColor footColor = new FootColor();
            Proforma proforma = new Proforma();

            product.Id = createOrderDto.ProductId;
            productColor.Id = createOrderDto.ProductColorId;
            fabric.Id = createOrderDto.FabricId;
            fabricColor.Id = createOrderDto.FabricColorId;
            foot.Id = createOrderDto.FootId;
            footColor.Id = createOrderDto.FootColorId;
            proforma.Id = createOrderDto.ProformaId;

            product.Id = createOrderDto.ProductId;
            order.Amount = createOrderDto.Amount;
            order.Discount = createOrderDto.Discount;
            order.Piece = createOrderDto.Piece;
            order.Price = createOrderDto.Price;
            order.TotalPrice = createOrderDto.TotalPrice;
            order.Product = product;
            order.ProductColor = productColor;
            order.Fabric = fabric;
            order.FabricColor = fabricColor;
            order.Foot = foot;
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

        public List<Order> GetAll()
        {
            return _orderDal.GetAll();
            //return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.OrderListed);
        }

        public Order GetById(int id)
        {
            return _orderDal.Get(c => c.Id == id);
            //return new SuccessDataResult<Order>(_orderDal.Get(c => c.Id == id));
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
            
            //return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
