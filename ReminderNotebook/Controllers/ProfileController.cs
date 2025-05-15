using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ElectronicReminderApp.ViewModels;

namespace ElectronicReminderApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Challenge(); // Якщо не знайдено користувача — запропонувати увійти

            var model = new ProfileViewModel
            {
                Email = user.Email,
                UserName = user.UserName,
                // Додай інші властивості за потреби
            };

            return View(model);
        }
    }
}
