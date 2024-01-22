using BlazorShop.Data;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace BlazorShop.Services
{
    public class SmtpMailSender : ISmtpMailSender
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
		private readonly IConfiguration _config;

        public SmtpMailSender(IConfiguration config)
        {
            _config = config;
		}

        public async Task SendMailAsync(string to, string subject, string body)
		{
			var message = new MimeMessage();

			var SmtpServer = _config["SmtpConfig:SmtpServer"];
			var Port = Convert.ToInt32(_config["SmtpConfig:Port"]);
			var Username = _config["SmtpConfig:Username"];
			var Password = _config["SmtpConfig:Password"];
			message.From.Add(new MailboxAddress("Server Notification", Username));
			message.To.Add(new MailboxAddress("Alexander", to));
			message.Subject = subject;

			message.Body = new TextPart(MimeKit.Text.TextFormat.Text)
			{
				Text = body
			};

			using (var client = new SmtpClient())
			{
				await client.ConnectAsync(SmtpServer, Port, false);
				await client.AuthenticateAsync(Username, Password);
				await client.SendAsync(message);
				await client.DisconnectAsync(true);
			}
		}

	}

}
