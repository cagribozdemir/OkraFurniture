using Microsoft.AspNetCore.Mvc;

namespace OkraFurnitureUI.ViewComponents.Default
{
    public class _SidebarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
