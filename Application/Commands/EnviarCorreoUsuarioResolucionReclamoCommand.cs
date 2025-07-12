using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.Commands
{
    /// <summary>
    /// Clase Command que se encarga de enviar la solicitud de querer notificar a un usuario que su reclamo de una subasta ha sido atendido.
    /// </summary>
    public class EnviarCorreoUsuarioResolucionReclamoCommand : IRequest<bool>
    {
        /// <summary>
        /// Atributo DTO que se encarga de recibir la información de la subasta sobre la que se hizo el reclamo, la resolución del reclamo y el correo del usuario..
        /// </summary>
        public CorreoUsuarioResoluciónReclamoDTO reclamoDto { get; set; }

        public EnviarCorreoUsuarioResolucionReclamoCommand(CorreoUsuarioResoluciónReclamoDTO reclamoDto)
        {
            this.reclamoDto = reclamoDto;
        }
    }
}
