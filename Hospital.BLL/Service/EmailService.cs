using Microsoft.Extensions.Configuration;

using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Service
{
    public class EmailService
    {
        private readonly IConfiguration _config;
       
        public EmailService(IConfiguration config)
        {
            _config = config;
           
        }
        public void SendEmail(string recipient)
        {
            // Email sending logic
            Console.WriteLine($"Email sent to {recipient}");
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(
                    _config.GetSection("EmailSettings")["Username"],
                    _config["EmailSettings:Password"]),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_config["EmailSettings:Username"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = false,
            };
            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }


    }
}
