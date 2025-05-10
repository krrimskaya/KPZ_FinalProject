using ElectronicReminderApp.Models;
using ElectronicReminderApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicReminderApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FileDataService _fileDataService;

        public HomeController()
        {
            _fileDataService = new FileDataService();
        }

        // Дія для відображення сторінки з нагадуваннями
        public IActionResult Index()
        {
            var reminders = _fileDataService.LoadReminders();
            return View(reminders);
        }

        // Дія для додавання нового нагадування
        [HttpPost]
        public IActionResult Add(Reminder reminder)
        {
            var reminders = _fileDataService.LoadReminders();
            reminders.Add(reminder);
            _fileDataService.SaveReminders(reminders);
            return RedirectToAction("Index");
        }

        // Дія для видалення нагадування
        public IActionResult Delete(int id)
        {
            var reminders = _fileDataService.LoadReminders();
            var reminderToDelete = reminders.FirstOrDefault(r => r.Id == id);
            if (reminderToDelete != null)
            {
                reminders.Remove(reminderToDelete);
                _fileDataService.SaveReminders(reminders);
            }
            return RedirectToAction("Index");
        }
    }
}
