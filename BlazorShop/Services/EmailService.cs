using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using BlazorShop.Data;

namespace BlazorShop.Services
{
    public class EmailService : IEmailService  // Заменил на SmtpMailSender
    {
		private string smtpServer = Environment.GetEnvironmentVariable("smtp-server");				
		private string emailLogin = Environment.GetEnvironmentVariable("email_login");
		private string emailPassword = Environment.GetEnvironmentVariable("email_password");


		public async Task SendEmailAsync(string email, string subject, string message)
		{
			using var emailMessage = new MimeMessage();

			emailMessage.From.Add(new MailboxAddress("Server Notification", emailLogin));

			emailMessage.To.Add(new MailboxAddress("Alexander", email));
			emailMessage.Subject = subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
			{
				Text = message
			};

			using (var client = new SmtpClient())
			{
				await client.ConnectAsync(smtpServer, 25, false);
				await client.AuthenticateAsync(emailLogin, emailPassword);
				await client.SendAsync(emailMessage);

				await client.DisconnectAsync(true);
			}
		}
	}


}
