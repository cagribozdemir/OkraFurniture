using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductColorService
    {
        List<ProductColor> GetAll();
        ProductColor GetById(int id);
        IResult Add(CreateProductColorDto createProductColorDto);
        IResult Update(ProductColor productColor);
        void Delete(int id);
    }
}
