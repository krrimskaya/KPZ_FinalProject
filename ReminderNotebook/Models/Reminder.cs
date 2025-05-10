namespace ElectronicReminderApp.Models
{
    public class Reminder
    {
        public int Id { get; set; }  // Унікальний ідентифікатор
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
