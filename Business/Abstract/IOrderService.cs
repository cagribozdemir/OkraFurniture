using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetById(int id);
        void Add(CreateOrderDto createOrderDto);
        void Update(Order order);
        void Delete(int id);
    }
}
