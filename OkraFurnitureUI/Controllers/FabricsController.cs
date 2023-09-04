using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Fabric;
using Entity.DTOs.FabricColor;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class FabricsController : Controller
    {
        IFabricService _fabricService;

        public FabricsController(IFabricService fabricService)
        {
            _fabricService = fabricService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _fabricService.GetAll();
            return View(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _fabricService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddFabric()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFabric(CreateFabricDto createFabriDto)
        {
            _fabricService.Add(createFabriDto);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFabric(int id)
        {
            _fabricService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateFabric(int id)
        {
            var value = _fabricService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateFabric(Fabric fabric)
        {
            _fabricService.Update(fabric);
            return RedirectToAction("Index");
        }
    }
}