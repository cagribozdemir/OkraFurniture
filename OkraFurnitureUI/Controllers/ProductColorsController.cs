using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.ProductColor;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ProductColorsController : Controller
    {
        IProductColorService _productColorService;

        public ProductColorsController(IProductColorService productColorService)
        {
            _productColorService = productColorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _productColorService.GetAll();
            return View(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _productColorService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddProductColor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProductColor(CreateProductColorDto createProductColorDto)
        {
            _productColorService.Add(createProductColorDto);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProductColor(int id)
        {
            _productColorService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProductColor(int id)
        {
            var value = _productColorService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProductColor(ProductColor productColor)
        {
            _productColorService.Update(productColor);
            return RedirectToAction("Index");
        }
    }
}
