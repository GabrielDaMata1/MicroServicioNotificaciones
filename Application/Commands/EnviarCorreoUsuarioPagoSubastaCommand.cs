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
    /// Clase Command que se encarga de enviar la solicitud de querer notificar a un subastador sobre la recepción de un pago exitoso de una subasta.
    /// </summary>
    public class EnviarCorreoUsuarioPagoSubastaCommand : IRequest<bool>
    {
        /// <summary>
        /// Atributo DTO que se encarga de recibir la información de la subasta pagada, el correo del usuario ganador de la subasta, y monto del pago.
        /// </summary>
        public CorreoUsuarioPagoSubastaDTO pagoDto { get; set; }

        public EnviarCorreoUsuarioPagoSubastaCommand(CorreoUsuarioPagoSubastaDTO pagoDto)
        {
            this.pagoDto = pagoDto;
        }
    }
}
