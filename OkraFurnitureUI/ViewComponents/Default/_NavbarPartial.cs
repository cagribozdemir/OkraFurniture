using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OkraFurnitureUI.Models;

namespace OkraFurnitureUI.ViewComponents.Default
{
    public class _NavbarPartial : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public _NavbarPartial(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.FullName = values.Name + " " + values.Surname;
            userViewModel.ImageUrl = values.ImageUrl;

            return View(userViewModel);
        }
    }
}
