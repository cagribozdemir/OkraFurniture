using Microsoft.AspNetCore.Mvc;

namespace OkraFurnitureUI.ViewComponents.Default
{
    public class _HeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
