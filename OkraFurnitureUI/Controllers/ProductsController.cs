using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Product;
using Entity.DTOs.ProductColor;
using Entity.DTOs.Proforma;
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
        public IActionResult Index()
        {
            var result = _productService.GetAll();
            return View(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> valueCategory = (from x in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            ViewBag.categoryVlc = valueCategory;
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
            List<SelectListItem> valueCategory = (from x in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            ViewBag.categoryVlc = valueCategory;
            var value = _productService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Index");
        }
    }
}
