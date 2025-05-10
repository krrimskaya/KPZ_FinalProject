using ElectronicReminderApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace ElectronicReminderApp.Services
{
    public class FileDataService
    {
        private readonly string filePath = "reminders.json";

        public List<Reminder> LoadReminders()
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Reminder>>(jsonData) ?? new List<Reminder>();
            }
            return new List<Reminder>();
        }

        public void SaveReminders(List<Reminder> reminders)
        {
            string jsonData = JsonSerializer.Serialize(reminders);
            File.WriteAllText(filePath, jsonData);
        }

        // Генерація нового унікального Id
        public int GetNextId()
        {
            var reminders = LoadReminders();
            return reminders.Any() ? reminders.Max(r => r.Id) + 1 : 1;
        }
    }
}
