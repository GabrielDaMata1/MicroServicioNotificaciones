using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using System.Net;
using System.Net.Mail;


namespace Infrastructure.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public SmtpEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string destinatario, string mensaje)
        {
            var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
            {
                Port = int.Parse(_configuration["Smtp:Port"]),
                Credentials = new NetworkCredential(_configuration["Smtp:User"], _configuration["Smtp:Password"]),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["Smtp:From"]),
                Subject = "Notificación",
                Body = mensaje,
                IsBodyHtml = false,
            };

            mailMessage.To.Add(destinatario);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}