using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.Order;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class OrdersController : Controller
    {
        IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _orderService.GetAll();
            return View(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _orderService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(CreateOrderDto createOrderDto)
        {
            _orderService.Add(createOrderDto);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteOrder(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateOrder(int id)
        {
            var value = _orderService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            _orderService.Update(order);
            return RedirectToAction("Index");
        }
    }
}
