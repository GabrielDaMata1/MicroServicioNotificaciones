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
    /// Clase Command que se encarga de enviar la solicitud de querer notificar a un usuario que el pago de una subasta ni pudo ser procesado con éxito.
    /// </summary>
    public class EnviarCorreoPagoSubastaFallidoCommand : IRequest<bool>
    {
        /// <summary>
        /// Atributo DTO que se encarga de recibir la información de la subasta pagada fallidamente, monto del pago, y el correo del usuario.
        /// </summary>
        public CorreoUsuarioPagoSubastaFallidoDTO  pagoDTO { get; set; }

        public EnviarCorreoPagoSubastaFallidoCommand(CorreoUsuarioPagoSubastaFallidoDTO pagoDTO)
        {
            this.pagoDTO = pagoDTO;
        }
    }
}
