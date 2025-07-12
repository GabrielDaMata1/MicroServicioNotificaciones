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
    /// Clase Command que se encarga de enviar la solicitud de querer notificar a un usuario que su puja automática ha llegado al límite del monto máximo en la subasta donde participaba.
    /// </summary>
    public class EnviarCorreoUsuarioPujaAutomaticaAcabadaCommand : IRequest<bool>
    {
        /// <summary>
        /// Atributo DTO que se encarga de recibir la información de la subasta en la que participaba, y el correo del usuario.
        /// </summary>
        public CorreoUsuarioPujaAutomaticaAcabadaDTO usuarioDTO { get; set; }

       public EnviarCorreoUsuarioPujaAutomaticaAcabadaCommand(CorreoUsuarioPujaAutomaticaAcabadaDTO usuarioDto)
       {
           usuarioDTO = usuarioDto;
       }
    }
}
