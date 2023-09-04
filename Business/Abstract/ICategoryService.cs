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
        void Add(CreateCategoryDto createCategoryDto);
        void Update(Category category);
        void Delete(int id);
    }
}
