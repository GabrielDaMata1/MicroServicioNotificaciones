using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    /// <summary>
    /// Clase DTO que se encarga de encapsular la información necesaria para notificar a un usuario que su puja automática en una subasta ha llegado a su límite.
    /// </summary>
    public class CorreoUsuarioPujaAutomaticaAcabadaDTO
    {
        /// <summary>
        /// Atributo que corresponde al usuario quién recibe el correo.
        /// </summary>
        public string Destinatario { get; set; }
        /// <summary>
        /// Atributo que corresponde al monto máximo declarado al registrar la puja automática en la subasta
        /// </summary>
        public decimal MontoMaximo { get; set; }
        /// <summary>
        /// Atributo que corresponde al nombre de la subasta en la que participaba.
        /// </summary>
        public string NombreSubasta { get; set; }
        /// <summary>
        /// Atributo que corresponde al nombre del producto subastadp.
        /// </summary>
        public string NombreProducto { get; set; }

    }
}
