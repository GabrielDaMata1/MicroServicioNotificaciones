using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Value_Objects
{
    public class ContenidoNotificacionVO
    {
        public string contenidoNotificacion { get; set; }

        public ContenidoNotificacionVO(string contenidoNotificacion)
        {
            this.contenidoNotificacion = contenidoNotificacion;
        }
    }
}
