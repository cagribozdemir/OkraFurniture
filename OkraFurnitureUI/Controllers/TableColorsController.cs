using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.TableColor;
using Microsoft.AspNetCore.Mvc;

namespace OkraFurnitureUI.Controllers
{
    public class TableColorsController : Controller
    {
        ITableColorService _tableColorService;

        public TableColorsController(ITableColorService tableColorService)
        {
            _tableColorService = tableColorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _tableColorService.GetAll();
            return View(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _tableColorService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddTableColor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTableColor(CreateTableColorDto createTableColorDto)
        {
            _tableColorService.Add(createTableColorDto);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTableColor(int id)
        {
            _tableColorService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTableColor(int id)
        {
            var value = _tableColorService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateTableColor(TableColor tableColor)
        {
            _tableColorService.Update(tableColor);
            return RedirectToAction("Index");
        }
    }
}
