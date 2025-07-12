using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    /// <summary>
    /// Clase DTO que se encarga de encapsular la información necesaria para notificar al subastador sobre el reclamo de un premio por parte del ganador de una subasta.
    /// </summary>
    public class CorreoReclamoPremioDTO
    {
        /// <summary>
        /// Atributo que corresponde al subastador quién recibe el correo.
        /// </summary>
        public string Destinatario { get; set; }
        /// <summary>
        /// Atributo que corresponde al nombre de la subasta en la que ganó.
        /// </summary>
        public string NombreSubasta { get; set; }
        /// <summary>
        /// Atributo que corresponde al usuario quién ganó la subasta.
        /// </summary>
        public string CorreoUsuario { get; set; }
    }
}
