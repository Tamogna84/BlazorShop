namespace BlazorShop.Data
{
    // Интерфейс для сервиса отправки Email
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
