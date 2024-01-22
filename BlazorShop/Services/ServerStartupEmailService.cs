using BlazorShop.Data;

namespace BlazorShop.Services
{
	// сервис для отправки сообщения по Email при запуске сервера
	public class ServerStartupEmailService
	{
		private readonly IEmailService _emailService;

		//readonly string Email = Environment.GetEnvironmentVariable("MainEmail"); // Переменная среды

		private readonly IConfiguration _config;

		public ServerStartupEmailService(IEmailService emailService)
		{
			_emailService = emailService;
		}

		public async Task SendServerStartupMessage()
		{
			var Email = _config["SmtpConfig:Email"];
			await _emailService.SendEmailAsync(Email, "Server Started", "Сервер запущен. Сообщение отправлено.");
		}
	}


}
