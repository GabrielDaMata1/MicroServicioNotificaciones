using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    /// <summary>
    /// Clase DTO que se encarga de encapsular la información necesaria para notificar al usuario ganador y al subastador sobre la cancelación de la subasta por falta de pago
    /// </summary>
    public class CorreoSubastaCanceladaDTO
    {
        /// <summary>
        /// Atributo que corresponde al subastador quién recibe el correo.
        /// </summary>
        public string CorreoSubastador { get; set; }
        /// <summary>
        /// Atributo que corresponde al usuario quién recibe el correo.
        /// </summary>
        public string CorreoUsuario { get; set; }
        /// <summary>
        /// Atributo que corresponde al nombre de la subasta que se canceló.
        /// </summary>
        public string NombreSubasta { get; set; }
        /// <summary>
        /// Atributo que corresponde al nombre del producto subastadp.
        /// </summary>
        public string NombreProducto { get; set; }
    }
}
