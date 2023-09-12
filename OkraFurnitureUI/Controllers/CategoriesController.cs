using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Category;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CategoriesController : Controller
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _categoryService.GetAll();
            return View(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto createCategoryDto)
        {
            var result = _categoryService.Add(createCategoryDto);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _categoryService.GetById(id);
            return View(value);

        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }
    }
}
