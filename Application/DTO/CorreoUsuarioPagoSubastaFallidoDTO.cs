using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    /// <summary>
    /// Clase DTO que se encarga de encapsular la información necesaria para notificar a un usuario que su pago fue procesado con éxito.
    /// </summary>
    public class CorreoUsuarioPagoSubastaFallidoDTO
    {
        /// <summary>
        /// Atributo que corresponde al usuario quién recibe el correo.
        /// </summary>
        public string Destinatario { get; set; }
        /// <summary>
        /// Atributo que corresponde al monto pagado de la subasta.
        /// </summary>
        public decimal MontoPago{ get; set; }
        /// <summary>
        /// Atributo que corresponde al nombre de la subasta que pagó.
        /// </summary>
        public string NombreSubasta { get; set; }

    }
}
