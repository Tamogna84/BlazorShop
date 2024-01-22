using BlazorShop.Data;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Services
{
    public class SmtpEmailSenderOptions
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
