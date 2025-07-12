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
    /// Clase Handler que se encarga notificar al subastador cuando una de las subastas que organiza ha acabado y con un ganador.
    /// </summary>
    public class EnviarCorreoSubastadorSubastaFinalizadaHandler : IRequestHandler<EnviarCorreoSubastadorSubastaFinalizadaCommand, bool>
    {
        /// <summary>
        /// Atributo que corresponde a las operaciones posibles que se pueden realizar sobre un correo, el cual será inyectado por inversión de dependencias.
        /// </summary>
        private readonly IEmailSender _emailSender;

        public EnviarCorreoSubastadorSubastaFinalizadaHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        /// <summary>
        /// Metodo que se encarga de procesar el envio de un correo al subastador con los datos del ganador cuando una subasta es finalizada.
        /// </summary>
        /// <param name="request">Parametro que contiene un DTO con el nombre del producto y de la subasta que finalizó, y el correo del usuario ganador y del subastador.</param>
        /// <returns>Retorna un valor booleano si todas las operaciones fueron exitosas.</returns>
        /// <exception cref="FalloAlEnviarCorreoException">
        /// Esta excepcion ocurre si no se pudo enviar el correo al subastador.
        /// </exception>

        public async Task<bool> Handle(EnviarCorreoSubastadorSubastaFinalizadaCommand request, CancellationToken cancellationToken)
        {

            try
            {
                // Se genera el contenido del correo a enviar.
                var contenidoCorreo = GeneradorContenidoCorreo.ContenidoSubastadorSubastaFinalizada(request.correoDTO.NombreSubasta, request.correoDTO.NombreProducto, request.correoDTO.CorreoGanador,request.correoDTO.MontoGanador );

                //Se crea la instancia de la entidad Notificacion
                var notificacion = new Notificacion(new DestinatarioNotificaciónVO(request.correoDTO.Destinatario), new ContenidoNotificacionVO(contenidoCorreo.Html), new AsuntoNotificacionVO(contenidoCorreo.Asunto));

                //Se envia el correo personalizado al subastador que organizó la subasta. 
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
