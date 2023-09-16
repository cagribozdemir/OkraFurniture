using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PdfSharpCore.Pdf;
using PdfSharpCore;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace WebApi.Controllers
{
    public class OrdersController : Controller
    {
        IOrderService _orderService;
        IProductService _productService;
        IProductColorService _productColorService;
        IFootService _footService;
        IFootColorService _footColorService;
        IFabricService _fabricService;
        IProformaService _proformaService;
        ICategoryService _categoryService;

        public OrdersController(IOrderService orderService, IProductService productService, IProductColorService productColorService,
            IFootColorService footColorService, IFabricService fabricService, IProformaService proformaService, IFootService footService, ICategoryService categoryService)
        {
            _orderService = orderService;
            _productService = productService;
            _productColorService = productColorService;
            _footColorService = footColorService;
            _fabricService = fabricService;
            _proformaService = proformaService;
            _footService = footService;
            _categoryService = categoryService;
        }

        [HttpGet("Orders/GetByProformaId/{proformaId}")]
        public IActionResult GetByProformaId(int proformaId)
        {
            var result = _orderService.GetByProformaId(proformaId);
            ViewBag.ProformaId = proformaId;

            ViewBag.ProformaCompany = _proformaService.GetById(proformaId).CompanyName;
            ViewBag.ProformaAddress = _proformaService.GetById(proformaId).Address;
            ViewBag.ProformaDate = _proformaService.GetById(proformaId).Date;

            return View(result);
        }

        [HttpGet]
        public IActionResult AddOrder(int id)
        {
            var categories = _categoryService.GetAll();
            var fabrics = _fabricService.GetAll();
            var productColors = _productColorService.GetAll();
            var footColors = _footColorService.GetAll();
            var feet = _footService.GetAll();
            
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            ViewBag.FabricList = new SelectList(fabrics, "Id", "Name");
            ViewBag.ProductColorList = new SelectList(productColors, "Id", "Name");
            ViewBag.FootColorList = new SelectList(footColors, "Id", "Name");
            ViewBag.FootList = new SelectList(feet, "Id", "Name");

            ViewBag.proformaId = id;

            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(CreateOrderDto createOrderDto)
        {
            _orderService.Add(createOrderDto);
            return RedirectToAction("GetByProformaId","Orders", new { proformaId = createOrderDto.ProformaId });
        }

        public IActionResult DeleteOrder(int id, int proformaId)
        {
            _orderService.Delete(id);
            return RedirectToAction("GetByProformaId", "Orders", new { proformaId = proformaId });
        }

        [HttpGet]
        public IActionResult UpdateOrder(int id)
        {
            #region SelectListItem
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

            List<SelectListItem> valueFoot = (from x in _footService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.footVlc = valueFoot;
            #endregion
            var value = _orderService.GetById(id);
            ViewBag.proformaId = value.ProformaId;
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            _orderService.Update(order);
            return RedirectToAction("GetByProformaId", "Orders", new { proformaId = order.ProformaId });
        }

        [HttpGet("getPdf")]
        public async Task<IActionResult> GetPdf(int id) 
        {
            var document = new PdfDocument();
            string htmlContent = "<h1>Deneme</h1>";
            PdfGenerator.AddPdfPages(document, htmlContent, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            string fileName = "Invoice_" + id + ".pdf";
            return File(response, "application/pdf", fileName);
        }
    }
}
