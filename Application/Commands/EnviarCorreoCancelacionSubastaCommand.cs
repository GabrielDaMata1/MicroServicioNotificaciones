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
    /// Clase Command que se encarga de enviar la solicitud de querer notificar a un usuario y a un subastador sobre la cancelación de la subasta por falta de pago.
    /// </summary>
    public class EnviarCorreoCancelacionSubastaCommand : IRequest<bool>
    {
        /// <summary>
        /// Atributo DTO que se encarga de recibir la información de la subasta a cancelar, y los correos del usuario y del subastador.
        /// </summary>
        public CorreoSubastaCanceladaDTO subastaDTO { get; set; }

        public EnviarCorreoCancelacionSubastaCommand(CorreoSubastaCanceladaDTO subastaDto)
        {
            subastaDTO= subastaDto;
        }
    }
}
