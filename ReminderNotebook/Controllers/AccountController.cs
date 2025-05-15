using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ElectronicReminderApp.ViewModels;

namespace ElectronicReminderApp.Controllers
{
    [Authorize] // Захищає всі методи контролера, треба авторизація
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        // Конструктор для інжекції UserManager
        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: /Account/Profile
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            // Отримуємо поточного користувача із контексту
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                // Якщо користувача немає (наприклад, сесія завершена), перекидаємо на логін
                return Challenge();
            }

            // Заповнюємо модель даними користувача
            var model = new ProfileViewModel
            {
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = await _userManager.GetPhoneNumberAsync(user),
                // Можна додати інші властивості, якщо потрібно
            };

            // Повертаємо View із моделлю
            return View(model); // Автоматично шукає Views/Account/Profile.cshtml
        }

        // Тут можуть бути інші методи контролера, наприклад Login, Register, Logout...
    }
}
