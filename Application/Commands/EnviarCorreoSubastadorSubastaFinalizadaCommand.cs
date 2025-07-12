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
    /// Clase Command que se encarga de enviar la solicitud de querer notificar a un subastador sobre la finalización de una de sus subastas.
    /// </summary>
    public class EnviarCorreoSubastadorSubastaFinalizadaCommand : IRequest<bool>
    {
        /// <summary>
        /// Atributo DTO que se encarga de recibir la información de la subasta finalizada, y el correo del usuario ganador de la subasta.
        /// </summary>
        public CorreoSubastadorSubastaFinalizadaDTO correoDTO { get; set; }

        public EnviarCorreoSubastadorSubastaFinalizadaCommand (CorreoSubastadorSubastaFinalizadaDTO correoDTO)
        {
            this.correoDTO = correoDTO;
        }
    }
}
