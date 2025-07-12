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
    /// Clase Command que se encarga de enviar la solicitud de querer notificar a un usuario que es el ganador de una subasta.
    /// </summary>
    public class EnviarCorreoGanadorSubastaCommand : IRequest<bool>
    {
        /// <summary>
        /// Atributo DTO que se encarga de recibir la información de la subasta ganada, y el correo del usuario.
        /// </summary>
        public CorreoGanadorSubastaDTO correoDTO { get; set; }

        public EnviarCorreoGanadorSubastaCommand (CorreoGanadorSubastaDTO correoDTO)
        {
            this.correoDTO = correoDTO;
        }
    }
}
