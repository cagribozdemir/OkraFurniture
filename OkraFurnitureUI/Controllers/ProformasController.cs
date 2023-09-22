using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.Order;
using Entity.DTOs.Proforma;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OkraFurnitureUI.Models;

namespace WebApi.Controllers
{
    public class ProformasController : Controller
    {
        IProformaService _proformaService;
        private readonly UserManager<User> _userManager;

        public ProformasController(IProformaService proformaService, UserManager<User> userManager)
        {
            _proformaService = proformaService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _proformaService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddProforma()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProforma(CreateProformaDto createProformaDto)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            char firstChar = values.Name[0];
            var proformas = _proformaService.GetAll();
            int proformaId = 0;
            foreach (var proforma in proformas)
            {
                proformaId = proforma.Id;
            }
            createProformaDto.ReceiptNo = firstChar + (proformaId+101).ToString();
            _proformaService.Add(createProformaDto);
            return RedirectToAction("GetByProformaId", "Orders", new { proformaId = proformaId+1 });
        }

        public IActionResult DeleteProforma(int id)
        {
            _proformaService.Delete(id);
            return RedirectToAction("GetAll", "Proformas");
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
            return RedirectToAction("GetByProformaId", "Orders", new { proformaId = proforma.Id });
        }
    }
}
