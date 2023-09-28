using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApi.Controllers
{
    public class ProductsController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = _productService.GetAll();
            return View(result);
        }

        [HttpGet("Products/GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            return Json(result);
        }

        [HttpGet("Products/GetByCode/{code}")]
        public IActionResult GetByCode(string code)
        {
            var result = _productService.GetByCode(code);
            return Json(result);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var categories = _categoryService.GetAll();
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductDto createProductDto)
        {
            _productService.Add(createProductDto);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var categories = _categoryService.GetAll();
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            var value = _productService.GetById(id);
            ViewBag.SelectedCategoryName = _categoryService.GetById(value.CategoryId).Name;
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Index");
        }

        [HttpGet("Products/GetProductsByCategoryId/{categoryId}")]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            var products = _productService.GetAllByCategoryId(categoryId);
            return Json(products);
        }

        [HttpGet("Products/GetAllByKaputhane/{isKaputhane}")]
        public IActionResult GetAllByKaputhane(bool isKaputhane)
        {
            var products = _productService.GetAllByKaputhane(isKaputhane);
            return Json(products);
        }
    }
}
