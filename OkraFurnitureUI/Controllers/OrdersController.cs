using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApi.Controllers
{
    public class OrdersController : Controller
    {
        IOrderService _orderService;
        IProductService _productService;
        IProductColorService _productColorService;
        IFootColorService _footColorService;
        IFabricService _fabricService;

        public OrdersController(IOrderService orderService, IProductService productService, IProductColorService productColorService,
            IFootColorService footColorService, IFabricService fabricService)
        {
            _orderService = orderService;
            _productService = productService;
            _productColorService = productColorService;
            _footColorService = footColorService;
            _fabricService = fabricService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
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
            List<SelectListItem> valueCategory = (from x in _productService.GetAll()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.CategoryName,
                                                         Value = x.Id.ToString()
                                                     }).ToList();
            ViewBag.categoryVlc = valueCategory;

            List<SelectListItem> valueProductCode = (from x in _productService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Code,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.productCodeVlc = valueProductCode;

            List<SelectListItem> valueProduct = (from x in _productService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            ViewBag.productVlc = valueProduct;

            List<SelectListItem> valueFabric = (from x in _fabricService.GetAll()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.Id.ToString()
                                                      }).ToList();
            ViewBag.fabricVlc = valueFabric;

            List<SelectListItem> valueProductColor = (from x in _productColorService.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.productColorVlc = valueProductColor;


            List<SelectListItem> valueFootColor = (from x in _footColorService.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            ViewBag.footColorVlc = valueFootColor;

            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(CreateOrderDto createOrderDto)
        {
            _orderService.Add(createOrderDto);
            return RedirectToAction("GetAll");
        }

        public IActionResult DeleteOrder(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult UpdateOrder(int id)
        {
            List<SelectListItem> valueCategory = (from x in _productService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            ViewBag.categoryVlc = valueCategory;

            List<SelectListItem> valueProductCode = (from x in _productService.GetAll()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Code,
                                                         Value = x.Id.ToString()
                                                     }).ToList();
            ViewBag.productCodeVlc = valueProductCode;

            List<SelectListItem> valueProduct = (from x in _productService.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.productVlc = valueProduct;

            List<SelectListItem> valueFabric = (from x in _fabricService.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            ViewBag.fabricVlc = valueFabric;

            List<SelectListItem> valueProductColor = (from x in _productColorService.GetAll()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.Id.ToString()
                                                      }).ToList();
            ViewBag.productColorVlc = valueProductColor;


            List<SelectListItem> valueFootColor = (from x in _footColorService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.footColorVlc = valueFootColor;

            var value = _orderService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            _orderService.Update(order);
            return RedirectToAction("GetAll");
        }
    }
}
