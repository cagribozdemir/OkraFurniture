using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.FootColor;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class FootColorsController : Controller
    {
        IFootColorService _footColorService;

        public FootColorsController(IFootColorService footColorService)
        {
            _footColorService = footColorService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _footColorService.GetAll();
            return View(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _footColorService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddFootColor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFootColor(CreateFootColorDto createFootColorDto)
        {
            _footColorService.Add(createFootColorDto);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFootColor(int id)
        {
            _footColorService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateFootColor(int id)
        {
            var value = _footColorService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateFootColor(FootColor footColor)
        {
            _footColorService.Update(footColor);
            return RedirectToAction("Index");
        }
    }
}
