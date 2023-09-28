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
        List<ResultOrderDto> GetAll();
        List<ResultOrderDto> GetByProformaId(int proformaId);
        List<ResultOrderDto> GetByFootId(int footId);
        List<ResultOrderDto> GetByProductId(int productId);
        Order GetById(int id);
        IResult Add(CreateOrderDto createOrderDto);
        IResult Update(Order order);
        void Delete(int id);
    }
}
