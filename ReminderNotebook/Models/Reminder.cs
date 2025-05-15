using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicReminderApp.Models
{
    public class Reminder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        // Нова властивість: теги як рядок через кому
        public string Tags { get; set; } = "";
    }
}
