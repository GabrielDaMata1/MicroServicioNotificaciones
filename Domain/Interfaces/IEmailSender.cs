using Domain.Entities;

namespace Application.Interfaces
{
    /// <summary>
    /// Clase interface que define las operaciones que se pueden hacer sobre una notificación mediante correo electrónico.
    /// </summary>

    public interface IEmailSender
    {
        /// <summary>
        /// Método que se encarga de enviar un correo electrónico utilizando los datos contenidos en una instancia del objeto Notificacion />.
        /// </summary>
        /// <param name="notificacion">
        /// Objeto que encapsula la información necesaria para generar y enviar el correo, incluyendo destinatario, asunto y contenido HTML </param>

        Task SendEmailAsync(Notificacion notificacion);
    }
}