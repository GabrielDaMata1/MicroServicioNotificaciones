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
    /// Clase Command que se encarga de enviar la solicitud de querer notificar a un subastador sobre la confirmación del reclamo de un premio del usuario ganador de una subasta.
    /// </summary>
    public class EnviarCorreoSubastadorConfirmacionReclamoPremioCommand : IRequest<bool>
    {
        /// <summary>
        /// Atributo DTO que se encarga de recibir la información de la subasta de la cual se reclama el premio, y el correo del usuario.
        /// </summary>
        public CorreoReclamoPremioDTO reclamoPremioDto { get; set; }

        public EnviarCorreoSubastadorConfirmacionReclamoPremioCommand(CorreoReclamoPremioDTO reclamoPremioDto)
        {
            this.reclamoPremioDto = reclamoPremioDto;
        }
    }
}
