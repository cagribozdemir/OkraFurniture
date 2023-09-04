using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.Proforma;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
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
            var result = _proformaService.GetAll();
            return View(result);
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
            return RedirectToAction("Index");
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
