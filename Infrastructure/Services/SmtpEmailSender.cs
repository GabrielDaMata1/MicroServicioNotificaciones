using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using System.Net;
using System.Net.Mail;
using Domain.Entities;


namespace Infrastructure.Email
{
    /// <summary>
    /// Clase service que se encarga de implementar las operaciones que se pueden hacer sobre una notificación mediante correo electrónico.
    /// </summary>

    public class SmtpEmailSender : IEmailSender
    {
        /// <summary>
        /// Atributo que corresponde a la configuración del sistema, y que proporciona los valores necesarios de configuración SMTP,
        /// como host, puerto, credenciales y dirección de origen.
        /// </summary>
        private readonly IConfiguration _configuration;

        public SmtpEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Método que se encarga de enviar un correo electrónico utilizando los datos contenidos en una instancia del objeto Notificacion />.
        /// </summary>
        /// <param name="notificacion">
        /// Objeto que encapsula la información necesaria para generar y enviar el correo, incluyendo destinatario, asunto y contenido HTML </param>
        public async Task SendEmailAsync(Notificacion notificacion)
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
                Subject = notificacion.asuntoNotificacion.asuntoNotificacion,
                Body = notificacion.contenidoNotificacion.contenidoNotificacion,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(notificacion.destinatarioNotificacion.destinatarioNotificacion);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}