namespace BlazorShop.Data
{
    // Интерфейс для сервиса отправки Email
    public interface ISmtpMailSender
    {
        Task SendMailAsync(string to, string subject, string body);
    }
}
