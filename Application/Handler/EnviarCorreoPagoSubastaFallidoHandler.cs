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
    /// Clase Handler que se encarga notificar al usuario cuando el pago de una subasta no ha sido procesado exitosamente.
    /// </summary>
    public class EnviarCorreoPagoSubastaFallidoHandler : IRequestHandler<EnviarCorreoPagoSubastaFallidoCommand, bool>
    {
        /// <summary>
        /// Atributo que corresponde a las operaciones posibles que se pueden realizar sobre un correo, el cual será inyectado por inversión de dependencias.
        /// </summary>
        private readonly IEmailSender _emailSender;

        public EnviarCorreoPagoSubastaFallidoHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        /// <summary>
        /// Metodo que se encarga de procesar el envio de un correo al usuario cuando su pago de una subasta ha fallado.
        /// </summary>
        /// <param name="request">Parametro que contiene un DTO con el nombre de la subasta que intentó pagar, el correo del usuario y el monto del pago.</param>
        /// <returns>Retorna un valor booleano si todas las operaciones fueron exitosas.</returns>
        /// <exception cref="FalloAlEnviarCorreoException">
        /// Esta excepcion ocurre si no se pudo enviar el correo al subastador.
        /// </exception>

        public async Task<bool> Handle(EnviarCorreoPagoSubastaFallidoCommand request, CancellationToken cancellationToken)
        {

            try
            {
                // Se genera el contenido del correo a enviar.
                var contenidoCorreo = GeneradorContenidoCorreo.ContenidoPagoFallidoSubasta(request.pagoDTO.NombreSubasta, request.pagoDTO.MontoPago);

                //Se crea la instancia de la entidad Notificacion
                var notificacion = new Notificacion(new DestinatarioNotificaciónVO(request.pagoDTO.Destinatario), new ContenidoNotificacionVO(contenidoCorreo.Html), new AsuntoNotificacionVO(contenidoCorreo.Asunto));

                //Se envia el correo personalizado al usuario que realizó el pago 
                await _emailSender.SendEmailAsync(notificacion);

                return true;

            }
            catch (System.Exception ex)
            {
                throw new FalloAlEnviarCorreoException("Ha ocurrido un error al enviar el correo al subastador", ex);
            }
        }
    }
}
