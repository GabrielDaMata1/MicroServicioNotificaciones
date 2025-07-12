using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Value_Objects;

namespace Domain.Entities
{
    /// <summary>
    /// Clase Entity que representa a la entidad Notificación en el dominio del sistema.
    /// </summary>
    public class Notificacion
    {
        /// <summary>
        /// Atributo que corresponde al destinatario de la notificación a enviar.
        /// </summary>
        public DestinatarioNotificaciónVO destinatarioNotificacion { get; set; }
        /// <summary>
        /// Atributo que corresponde al contenido de la notificación a enviar.
        /// </summary>
        public ContenidoNotificacionVO contenidoNotificacion { get; set; }
        /// <summary>
        /// Atributo que corresponde al asunto de la notificación a enviar.
        /// </summary>
        public AsuntoNotificacionVO asuntoNotificacion { get; set; }

        public Notificacion(DestinatarioNotificaciónVO destinatario, ContenidoNotificacionVO contenido, AsuntoNotificacionVO asunto)
        {
            destinatarioNotificacion=destinatario;
            contenidoNotificacion=contenido;
            asuntoNotificacion=asunto;
        }
    }
}
