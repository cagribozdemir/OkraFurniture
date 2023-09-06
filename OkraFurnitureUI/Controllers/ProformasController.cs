using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.Order;
using Entity.DTOs.Proforma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OkraFurnitureUI.Models;

namespace WebApi.Controllers
{
    public class ProformasController : Controller
    {
        IProformaService _proformaService;
        IOrderService _orderService;
        IProductService _productService;
        IProductColorService _productColorService;
        IFootColorService _footColorService;
        IFabricService _fabricService;

        public ProformasController(IProformaService proformaService, IOrderService orderService, IProductService productService,
            IProductColorService productColorService, IFootColorService footColorService, IFabricService fabricService)
        {
            _proformaService = proformaService;
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
            var jsonOrders = JsonConvert.SerializeObject(_proformaService.GetAll());
            return Json(jsonOrders);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _proformaService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddProforma()
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
        public IActionResult AddProforma(CreateProformaDto createProformaDto)
        {
            _proformaService.Add(createProformaDto);
            return RedirectToAction("AddProforma");
        }

        public IActionResult DeleteCategory(int id)
        {
            _proformaService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProforma(int id)
        {
            var value = _proformaService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProforma(Proforma proforma)
        {
            _proformaService.Update(proforma);
            return RedirectToAction("Index");
        }
    }
}
