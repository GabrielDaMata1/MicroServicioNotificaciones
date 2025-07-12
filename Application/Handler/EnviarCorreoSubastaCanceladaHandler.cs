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
    /// Clase Handler que se encarga notificar al usuario y al subastador cuando una subasta es cancelada por falta de pago.
    /// </summary>
    public class EnviarCorreoSubastaCanceladaHandler : IRequestHandler<EnviarCorreoCancelacionSubastaCommand, bool>
    {
        /// <summary>
        /// Atributo que corresponde a las operaciones posibles que se pueden realizar sobre un correo, el cual será inyectado por inversión de dependencias.
        /// </summary>
        private readonly IEmailSender _emailSender;

        public EnviarCorreoSubastaCanceladaHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        /// <summary>
        /// Metodo que se encarga de procesar el envio de un correo al subastador y usuario cuando una subasta es cancelada por falta de pago.
        /// </summary>
        /// <param name="request">Parametro que contiene un DTO con el nombre del producto y de la subasta que finalizó, y el correo del usuario y del subastador.</param>
        /// <returns>Retorna un valor booleano si todas las operaciones fueron exitosas.</returns>
        /// <exception cref="FalloAlEnviarCorreoException">
        /// Esta excepcion ocurre si no se pudo enviar el correo al subastador.
        /// </exception>

        public async Task<bool> Handle(EnviarCorreoCancelacionSubastaCommand request, CancellationToken cancellationToken)
        {

            try
            {
                // Se genera el contenido del correo a enviar.
                var contenidoCorreo = GeneradorContenidoCorreo.ContenidoSubastaCancelada(request.subastaDTO.NombreProducto,request.subastaDTO.NombreSubasta);

                //Se crea la instancia de la entidad Notificacion para el usuario
                var notificacionUsuario = new Notificacion(new DestinatarioNotificaciónVO(request.subastaDTO.CorreoUsuario), new ContenidoNotificacionVO(contenidoCorreo.Html), new AsuntoNotificacionVO(contenidoCorreo.Asunto));

                //Se crea la instancia de la entidad Notificacion para el subastadir
                var notificacionSubastador = new Notificacion(new DestinatarioNotificaciónVO(request.subastaDTO.CorreoSubastador), new ContenidoNotificacionVO(contenidoCorreo.Html), new AsuntoNotificacionVO(contenidoCorreo.Asunto));

                //Se envia el correo personalizado al usuario
                await _emailSender.SendEmailAsync(notificacionUsuario);

                //Se envia el correo personalizado al subastador
                await _emailSender.SendEmailAsync(notificacionSubastador);


                return true;

            }
            catch (System.Exception ex)
            {
                throw new FalloAlEnviarCorreoException("Ha ocurrido un error al enviar el correo al subastador", ex);
            }
        }
    }
}
