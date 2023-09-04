using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductColorManager : IProductColorService
    {
        IProductColorDal _productColorDal;

        public ProductColorManager(IProductColorDal productColorDal)
        {
            _productColorDal = productColorDal;
        }
        public void Add(CreateProductColorDto createProductColorDto)
        {
            ProductColor productColor = new ProductColor();

            productColor.Name = createProductColorDto.Name;
            productColor.Code = createProductColorDto.Code;
            productColor.Status = true;

            _productColorDal.Add(productColor);

            //return new SuccessResult(Messages.ProductColorAdded);
        }

        public void Delete(int id)
        {
            ProductColor productColor = _productColorDal.Get(p => p.Id == id);
            _productColorDal.Delete(productColor);
            //return new SuccessResult(Messages.ProductColorDeleted);
        }

        public List<ProductColor> GetAll()
        {
            return _productColorDal.GetAll();
            //return new SuccessDataResult<List<ProductColor>>(_productColorDal.GetAll(), Messages.ProductColorListed);
        }

        public ProductColor GetById(int id)
        {
            return _productColorDal.Get(c => c.Id == id);
            //return new SuccessDataResult<ProductColor>(_productColorDal.Get(c => c.Id == id));
        }

        public void Update(ProductColor productColor)
        {
            _productColorDal.Update(productColor);

            //return new SuccessResult(Messages.ProductColorUpdated);
        }
    }
}
