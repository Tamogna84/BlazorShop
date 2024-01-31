namespace BlazorShop.Data
{
    // Интерфейс для сервиса отправки Email
    public interface ISmtpMailSender
    {
        public Task SendMailAsync(string to, string subject, string body);
    }
}
