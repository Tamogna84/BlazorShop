namespace BlazorShop.Data
{
    // Интерфейс для сервиса отправки Email
    public interface IEmailService   // заменил на ISmtpMailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
