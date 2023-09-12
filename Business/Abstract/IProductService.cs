using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<ResultProductDto> GetAll();
        List<Product> GetAllByCategoryId(int id);
        Product GetById(int id);
        IResult Add(CreateProductDto createProductDto);
        IResult Update(Product product);
        void Delete(int id);
    }
}
