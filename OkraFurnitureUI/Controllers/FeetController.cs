using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Foot;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class FeetController : Controller
    {
        IFootService _footService;

        public FeetController(IFootService footService)
        {
            _footService = footService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _footService.GetAll();
            return View(result);
        }

        [HttpGet("Feet/GetAll")]
        public IActionResult GetAll()
        {
            var result = _footService.GetAll();
            return Json(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _footService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddFoot()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFoot(CreateFootDto createFootDto)
        {
            _footService.Add(createFootDto);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFoot(int id)
        {
            _footService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateFoot(int id)
        {
            var value = _footService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateFoot(Foot foot)
        {
            _footService.Update(foot);
            return RedirectToAction("Index");
        }
    }
}
