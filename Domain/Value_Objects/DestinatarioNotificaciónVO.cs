using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Value_Objects
{
    public class DestinatarioNotificaciónVO
    {
        public string destinatarioNotificacion { get; set; }

        public DestinatarioNotificaciónVO(string destinatarioNotificacion)
        {
            this.destinatarioNotificacion = destinatarioNotificacion;
        }
    }
}
