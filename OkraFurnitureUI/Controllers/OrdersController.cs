﻿using Business.Abstract;
using Entity.Concrete;
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
            ViewBag.ProformaTotalPrice = _proformaService.GetById(proformaId).TotalPrice;
            ViewBag.ProformaPayment = _proformaService.GetById(proformaId).Payment;
            ViewBag.ProformaBalance = _proformaService.GetById(proformaId).Balance;

            return View(result);
        }

        [HttpGet("Orders/GetProductionsByFootId/{footId}")]
        public IActionResult GetProductionsByFootId(int footId)
        {
            var result = _orderService.GetProductionsByFootId(footId);

            return Json(result);
        }

        [HttpGet("Orders/GetProductionsByProductId/{productId}/{production}")]
        public IActionResult GetProductionsByProductId(int productId, int production)
        {
            var result = _orderService.GetProductionsByProductId(productId, production);

            return Json(result);
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
            var value = _orderService.GetById(id);
            
            var categories = _categoryService.GetAll();
            var products = _productService.GetAllByCategoryId(_productService.GetById(value.ProductId).CategoryId);
            var productColors = _productColorService.GetAll();
            var fabrics = _fabricService.GetAll();
            var footColors = _footColorService.GetAll();
            var feet = _footService.GetAll();

            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            ViewBag.ProductList = new SelectList(products, "Code", "Name");
            ViewBag.ProductCodeList = new SelectList(products, "Name", "Code");
            ViewBag.ProductColorList = new SelectList(productColors, "Id", "Name");
            ViewBag.FabricList = new SelectList(fabrics, "Id", "Name");
            ViewBag.FootColorList = new SelectList(footColors, "Id", "Name");
            ViewBag.FootList = new SelectList(feet, "Id", "Name");

            ViewBag.ProformaId = value.ProformaId;
            ViewBag.CategoryName = _categoryService.GetById(_productService.GetById(value.ProductId).CategoryId).Name;
            ViewBag.ProductName = _productService.GetById(value.ProductId).Name;
            ViewBag.ProductCode = _productService.GetById(value.ProductId).Code;
            ViewBag.ProductColorName = _productColorService.GetById(value.ProductColorId).Name;

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            _orderService.Update(order);
            return RedirectToAction("GetByProformaId", "Orders", new { proformaId = order.ProformaId });
        }

        [HttpGet("Orders/GetPdfFormat/{proformaId}")]
        public IActionResult GetPdfFormat(int proformaId)
        {
            var result = _orderService.GetByProformaId(proformaId);
            ViewBag.ProformaId = proformaId;

            ViewBag.ProformaReceiptNo = _proformaService.GetById(proformaId).ReceiptNo;
            ViewBag.ProformaCompany = _proformaService.GetById(proformaId).CompanyName;
            ViewBag.ProformaAddress = _proformaService.GetById(proformaId).Address;
            ViewBag.ProformaDate = _proformaService.GetById(proformaId).Date.ToLongDateString();
            ViewBag.ProformaTotalPrice = _proformaService.GetById(proformaId).TotalPrice;
            ViewBag.Payment = _proformaService.GetById(proformaId).Payment;
            ViewBag.Balance = _proformaService.GetById(proformaId).Balance;

            return View(result);
        }
    }
}
