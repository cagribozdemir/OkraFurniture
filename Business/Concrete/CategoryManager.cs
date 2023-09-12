using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public IResult Add(CreateCategoryDto createCategoryDto)
        {
            Category category = new Category();

            category.Name = createCategoryDto.Name;
            category.Code = createCategoryDto.Code;
            category.Status = true;

            _categoryDal.Add(category);

            return new SuccessResult(Messages.CategoryAdded);
        }

        public void Delete(int id)
        {
            Category category = _categoryDal.Get(c => c.Id == id);
            _categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll(); 
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(c => c.Id == id);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
