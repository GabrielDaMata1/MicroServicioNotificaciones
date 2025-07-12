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
    /// Clase Handler que se encarga notificar al subastador cuando el pago de una subasta ha sido procesado exitosamente.
    /// </summary>
    public class EnviarCorreoUsuarioPagoSubastaHandler : IRequestHandler<EnviarCorreoUsuarioPagoSubastaCommand, bool>
    {
        /// <summary>
        /// Atributo que corresponde a las operaciones posibles que se pueden realizar sobre un correo, el cual será inyectado por inversión de dependencias.
        /// </summary>
        private readonly IEmailSender _emailSender;

        public EnviarCorreoUsuarioPagoSubastaHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        /// <summary>
        /// Metodo que se encarga de procesar el envio de un correo al subastador cuando recibe un pago de una subasta finalizada.
        /// </summary>
        /// <param name="request">Parametro que contiene un DTO con el nombre de la subasta que pagada, el correo del usuario y el monto del pago.</param>
        /// <returns>Retorna un valor booleano si todas las operaciones fueron exitosas.</returns>
        /// <exception cref="FalloAlEnviarCorreoException">
        /// Esta excepcion ocurre si no se pudo enviar el correo al subastador.
        /// </exception>

        public async Task<bool> Handle(EnviarCorreoUsuarioPagoSubastaCommand request, CancellationToken cancellationToken)
        {

            try
            {
                // Se genera el contenido del correo a enviar.
                var contenidoCorreo = GeneradorContenidoCorreo.ContenidoPagoSubasta( request.pagoDto.NombreSubasta, request.pagoDto.MontoPago, request.pagoDto.CorreoUsuario);

                //Se crea la instancia de la entidad Notificacion
                var notificacion = new Notificacion(new DestinatarioNotificaciónVO(request.pagoDto.Destinatario), new ContenidoNotificacionVO(contenidoCorreo.Html), new AsuntoNotificacionVO(contenidoCorreo.Asunto));

                //Se envia el correo personalizado al subastador que recibió el pago de la subasta
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
