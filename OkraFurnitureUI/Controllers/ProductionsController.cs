using Microsoft.AspNetCore.Mvc;

namespace OkraFurnitureUI.Controllers
{
    public class ProductionsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Productions/Kaynakhane")]
        public IActionResult Kaynakhane()
        {
            return View();
        }

        [HttpGet("Productions/Kaputhane")]
        public IActionResult Kaputhane()
        {
            return View();
        }

        [HttpGet("Productions/Terzihane")]
        public IActionResult Terzihane()
        {
            return View();
        }

        [HttpGet("Productions/Dosemehane")]
        public IActionResult Dosemehane()
        {
            return View();
        }

        [HttpGet("Productions/Cnc")]
        public IActionResult Cnc()
        {
            return View();
        }

        [HttpGet("Productions/Boyahane")]
        public IActionResult Boyahane()
        {
            return View();
        }

        [HttpGet("Productions/Mobilyahane")]
        public IActionResult Mobilyahane()
        {
            return View();
        }
    }
}
