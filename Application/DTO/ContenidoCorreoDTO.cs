using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    /// <summary>
    /// Clase DTO que se encarga de encapsular la información necesaria para retornar el contenido y asunto del correo dependiendo del tipo de correo a generar
    /// </summary>
    public class ContenidoCorreoDTO
    {
        /// <summary>
        /// Atributo que corresponde al asunto del correo a enviar.
        /// </summary>
        public string Asunto { get; set; }
        /// <summary>
        /// Atributo que corresponde al contenido (En HTML) del correo a enviar.
        /// </summary>
        public string Html { get; set; }

    }
}
