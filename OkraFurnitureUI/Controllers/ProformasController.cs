using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.Order;
using Entity.DTOs.Proforma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OkraFurnitureUI.Models;

namespace WebApi.Controllers
{
    public class ProformasController : Controller
    {
        IProformaService _proformaService;

        public ProformasController(IProformaService proformaService)
        {
            _proformaService = proformaService;
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
            return View();
        }

        [HttpPost]
        public IActionResult AddProforma(CreateProformaDto createProformaDto)
        {
            _proformaService.Add(createProformaDto);
            int proformaId = 1;
            var proformas = _proformaService.GetAll();
            foreach (var proforma in proformas)
            {
                proformaId = proforma.Id;
            }
            return RedirectToAction("GetByProformaId", "Orders", new { proformaId = proformaId });
        }

        public IActionResult DeleteProforma(int id)
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
