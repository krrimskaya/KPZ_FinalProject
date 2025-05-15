using ElectronicReminderApp.Services;
using ElectronicReminderApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ElectronicReminderApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReminderService _reminderService;

        public HomeController(ReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        public async Task<IActionResult> Index()
        {
            var reminders = await _reminderService.GetAllAsync();
            return View(reminders);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Reminder reminder, string[] Tags)
        {
            if (ModelState.IsValid)
            {
                reminder.Tags = string.Join(",", Tags);
                await _reminderService.AddAsync(reminder);
                return RedirectToAction("Index");
            }
            var reminders = await _reminderService.GetAllAsync();
            return View("Index", reminders);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _reminderService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reminder = await _reminderService.GetByIdAsync(id);
            if (reminder == null)
            {
                return NotFound();
            }

            if (reminder.Date <= DateTime.Now.AddMinutes(1))
            {
                return RedirectToAction("Index");
            }

            return View(reminder);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Reminder reminder, string[] Tags)
        {
            if (ModelState.IsValid)
            {
                reminder.Tags = string.Join(",", Tags);
                await _reminderService.UpdateAsync(reminder);
                return RedirectToAction("Index");
            }
            return View(reminder);
        }
    }
}
