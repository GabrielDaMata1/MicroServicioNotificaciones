using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    /// <summary>
    /// Clase DTO que se encarga de encapsular la información necesaria para notificar al subastador que recibió un pago de una subasta por parte de un usuario.
    /// </summary>
    public class CorreoUsuarioPagoSubastaDTO
    {
        /// <summary>
        /// Atributo que corresponde al subastador quién recibe el correo.
        /// </summary>
        public string Destinatario { get; set; }
        /// <summary>
        /// Atributo que corresponde al monto pagado de la subasta.
        /// </summary>
        public decimal MontoPago{ get; set; }
        /// <summary>
        /// Atributo que corresponde al nombre de la subasta que organizó.
        /// </summary>
        public string NombreSubasta { get; set; }
        /// <summary>
        /// Atributo que corresponde al usuario que realizó el pago.
        /// </summary>
        public string CorreoUsuario { get; set; }
    }
}
