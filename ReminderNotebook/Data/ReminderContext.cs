using Microsoft.EntityFrameworkCore;
using ElectronicReminderApp.Models;

namespace ElectronicReminderApp.Data
{
    public class ReminderContext : DbContext
    {
        public ReminderContext(DbContextOptions<ReminderContext> options)
            : base(options)
        {
        }

        public DbSet<Reminder> Reminders { get; set; }
    }
}
