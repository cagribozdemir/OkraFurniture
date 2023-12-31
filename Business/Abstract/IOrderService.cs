﻿using Core.Utilities.Results;
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
        List<ResultOrderDto> GetProductionsByFootId(int footId);
        List<ResultOrderDto> GetProductionsByProductId(int productId, int production);
        Order GetById(int id);
        IResult Add(CreateOrderDto createOrderDto);
        IResult Update(Order order);
        void Delete(int id);
        void UpdateProcess(int id, int process);
    }
}
