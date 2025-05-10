using ElectronicReminderApp.Models;
using ElectronicReminderApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            reminder.Id = _fileDataService.GetNextId();  // Генерація унікального Id
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

        // Дія для відображення форми редагування
        public IActionResult Edit(int id)
        {
            var reminders = _fileDataService.LoadReminders();
            var reminder = reminders.FirstOrDefault(r => r.Id == id);
            if (reminder == null)
            {
                return NotFound();
            }

            // Перевірка, чи залишилось більше хвилини до нагадування
            if (reminder.Date <= DateTime.Now.AddMinutes(1))
            {
                return RedirectToAction("Index");
            }

            return View(reminder);
        }

        // Дія для обробки редагування нагадування
        [HttpPost]
        public IActionResult Edit(Reminder reminder)
        {
            var reminders = _fileDataService.LoadReminders();
            var reminderToUpdate = reminders.FirstOrDefault(r => r.Id == reminder.Id);
            if (reminderToUpdate != null)
            {
                reminderToUpdate.Title = reminder.Title;
                reminderToUpdate.Description = reminder.Description;
                reminderToUpdate.Date = reminder.Date;
                _fileDataService.SaveReminders(reminders);
            }
            return RedirectToAction("Index");
        }
    }
}
