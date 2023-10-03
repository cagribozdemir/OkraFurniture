using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Order;
using Microsoft.AspNetCore.Mvc;

namespace OkraFurnitureUI.Controllers
{
    public class ProductionsController : Controller
    {
        IOrderService _orderService;

        public ProductionsController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        #region Get Methods
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
        #endregion

        [HttpGet("Productions/UpdateProcess/{id}/{production}/{process}")]
        public IActionResult UpdateProcess(int id, string production, int process)
        {
            _orderService.UpdateProcess(id, process);
            return RedirectToAction(production, "Productions");
        }

    }
}
