using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commons;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Domain.Value_Objects;
using MediatR;

namespace Application.Handler
{
    /// <summary>
    /// Clase Handler que se encarga notificar al usuario cuando es el ganador de una subasta.
    /// </summary>
    public class EnviarCorreoGanadorSubastaHandler : IRequestHandler<EnviarCorreoGanadorSubastaCommand, bool>
    {
        /// <summary>
        /// Atributo que corresponde a las operaciones posibles que se pueden realizar sobre un correo, el cual será inyectado por inversión de dependencias.
        /// </summary>
        private readonly IEmailSender _emailSender;

        public EnviarCorreoGanadorSubastaHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        /// <summary>
        /// Metodo que se encarga de procesar el envio de un correo al usuario ganador de una subasta.
        /// </summary>
        /// <param name="request">Parametro que contiene un DTO con el nombre del producto y de la subasta en la que ganó, y el correo del usaurio ganador.</param>
        /// <returns>Retorna un DTO con los datos del medio de pago.</returns>
        /// <exception cref="FalloAlEnviarCorreoException">
        /// Esta excepcion ocurre si no se pudo enviar el correo al usuario.
        /// </exception>

        public async Task<bool> Handle(EnviarCorreoGanadorSubastaCommand request, CancellationToken cancellationToken)
        {

            try
            {
                // Se genera el contenido del correo a enviar.
                var contenidoCorreo = GeneradorContenidoCorreo.ContenidoGanadorSubasta(request.correoDTO.NombreProducto, request.correoDTO.NombreSubasta, request.correoDTO.MontoGanador);

                //Se crea la instancia de la entidad Notificacion
                var notificacion = new Notificacion(new DestinatarioNotificaciónVO(request.correoDTO.Destinatario), new ContenidoNotificacionVO(contenidoCorreo.Html), new AsuntoNotificacionVO(contenidoCorreo.Asunto));

                //Se envia el correo personalizado al usuario ganador de la subasta 
                await _emailSender.SendEmailAsync(notificacion);

                return true;

            }
            catch (System.Exception ex)
            {
                throw new FalloAlEnviarCorreoException("Ha ocurrido un error al enviar el correo al usuario", ex);
            }
        }
    }
}
