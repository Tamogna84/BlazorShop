using BlazorShop.Data;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace BlazorShop.Services
{
	public class SmtpMailSender : ISmtpMailSender, IAsyncDisposable
	{
		///    Пример испольлования IOptions

		//private readonly SmtpEmailSenderOptions _options;

		//public SmtpMailSender(IOptions<SmtpEmailSenderOptions> options)
		//{
		//    _options = options.Value;
		//}       

		//public async Task SendMailAsync(string to, string subject, string body)
		//      {
		//          var message = new MimeMessage();
		//          message.From.Add(new MailboxAddress("Server Notification", _options.Username));
		//          message.To.Add(new MailboxAddress("Alexander", to));
		//          message.Subject = subject;

		//          message.Body = new TextPart(MimeKit.Text.TextFormat.Text)
		//          {
		//              Text = body
		//          };

		//          using (var client = new SmtpClient())
		//          {
		//              await client.ConnectAsync(_options.SmtpServer, _options.Port, false);
		//              await client.AuthenticateAsync(_options.Username, _options.Password);
		//              await client.SendAsync(message);
		//              await client.DisconnectAsync(true);
		//          }
		//      }

		///    Пример испольлования User Secrets
		///    
		private readonly SmtpClient _client = new();
		
		private readonly IConfiguration _config;


		private readonly ILogger<SmtpMailSender> _logger;

		public SmtpMailSender(IConfiguration config, ILogger<SmtpMailSender> logger)
		{
			_config = config ?? throw new ArgumentNullException(nameof(config));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task SendMailAsync(string to, string subject, string body)
		{
			_logger.LogInformation("Sending email to {Email} with subject {Subject}", to, subject);

			var message = new MimeMessage();
			
			var Username = _config["SmtpConfig:Username"];
			
			message.From.Add(new MailboxAddress("Server Notification", Username));
			message.To.Add(new MailboxAddress("Alexander", to));
			message.Subject = subject;

			message.Body = new TextPart(MimeKit.Text.TextFormat.Text)
			{
				Text = body
			};

			await EnsureConnectedAndAuthed();
			await _client.SendAsync(message);
		}
		private async Task EnsureConnectedAndAuthed()
		{
			var SmtpServer = _config["SmtpConfig:SmtpServer"];
			var Port = Convert.ToInt32(_config["SmtpConfig:Port"]);
			var Username = _config["SmtpConfig:Username"];
			var Password = _config["SmtpConfig:Password"];
			if (!_client.IsConnected)
			{
				await _client.ConnectAsync(SmtpServer, Port, false);
			}
			if (!_client.IsAuthenticated)
			{
				await _client.AuthenticateAsync(Username, Password);
			}
		}

		// Вызовет DI контейнер, который вызовет DisposeAsync
		public async ValueTask DisposeAsync()
		{
			await _client.DisconnectAsync(true);
			_client.Dispose();
		}

	}

}
