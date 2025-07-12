using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    /// <summary>
    /// Clase DTO que se encarga de encapsular la información necesaria para notificar al subastador sobre la finalización de una de sus subastas.
    /// </summary>
    public class CorreoSubastadorSubastaFinalizadaDTO
    {
        /// <summary>
        /// Atributo que corresponde al subastador quién recibe el correo.
        /// </summary>
        public string Destinatario { get; set; }

        public decimal MontoGanador { get; set; }
        /// <summary>
        /// Atributo que corresponde al nombre de la subasta que organizó.
        /// </summary>
        public string NombreSubasta { get; set; }
        /// <summary>
        /// Atributo que corresponde al nombre del producto subastadp.
        /// </summary>
        public string NombreProducto { get; set; }
        /// <summary>
        /// Atributo que corresponde al usuario quién ganó la subasta.
        /// </summary>
        public string CorreoGanador { get; set; }
    }
}
