using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    /// <summary>
    /// Clase DTO que se encarga de encapsular la información necesaria para notificar a un usuario sobre la resolución de su reclamo de una subasta.
    /// </summary>
    public class CorreoUsuarioResoluciónReclamoDTO
    {
        /// <summary>
        /// Atributo que corresponde al usuario quién recibe el correo.
        /// </summary>
        public string Destinatario { get; set; }
        /// <summary>
        /// Atributo que corresponde al nombre de la subasta en la que ganó.
        /// </summary>
        public string NombreSubasta { get; set; }
        /// <summary>
        /// Atributo que corresponde a la resolución del reclamo de la subasta.
        /// </summary>
        public string Resolución { get; set; }
    }
}
