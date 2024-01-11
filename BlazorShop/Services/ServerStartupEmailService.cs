using BlazorShop.Data;

namespace BlazorShop.Services
{
	// сервис для отправки сообщения по Email при запуске сервера
	public class ServerStartupEmailService
	{
		private readonly IEmailService _emailService;

		readonly string Email = Environment.GetEnvironmentVariable("MainEmail");

		//private string Email = "naumov84alex@gmail.com";

		public ServerStartupEmailService(IEmailService emailService)
		{
			_emailService = emailService;
		}

		public async Task SendServerStartupMessage()
		{
			await _emailService.SendEmailAsync(Email, "Server Started", "Сервер запущен. Сообщение отправлено.");
		}
	}


}
