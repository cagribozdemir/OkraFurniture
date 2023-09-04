using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.FabricColor;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class FabricColorsController : Controller
    {
        IFabricColorService _fabricColorService;

        public FabricColorsController(IFabricColorService fabricColorService)
        {
            _fabricColorService = fabricColorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _fabricColorService.GetAll();
            return View(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _fabricColorService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddFabricColor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFabricColor(CreateFabricColorDto createFabricColorDto)
        {
            _fabricColorService.Add(createFabricColorDto);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFabricColor(int id)
        {
            _fabricColorService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateFabricColor(int id)
        {
            var value = _fabricColorService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateFabricColor(FabricColor fabricColor)
        {
            _fabricColorService.Update(fabricColor);
            return RedirectToAction("Index");
        }
    }
}
