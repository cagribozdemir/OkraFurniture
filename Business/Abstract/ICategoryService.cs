using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        IResult Add(CreateCategoryDto createCategoryDto);
        IResult Update(Category category);
        void Delete(int id);
    }
}
