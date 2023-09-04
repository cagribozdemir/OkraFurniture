using Microsoft.AspNetCore.Mvc;

namespace OkraFurnitureUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
