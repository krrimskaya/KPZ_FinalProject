namespace ElectronicReminderApp.ViewModels
{
    // Модель для передачі даних профілю у View
    public class ProfileViewModel
    {
        // Email користувача
        public string Email { get; set; }

        // Ім'я користувача (UserName)
        public string UserName { get; set; }

        // Телефон користувача (може бути null або пустим)
        public string PhoneNumber { get; set; }

        // Додаткові властивості можна додати за потребою
    }
}
