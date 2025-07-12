using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;

namespace TestMicroservicioNotificaciones.CommandTest
{
    public class EnviarCorreoUsuarioResolucionReclamoCommandTest
    {
        [Fact]
        public void Constructor_ShouldAssignReclamoDTO()
        {
            var dto = new CorreoUsuarioResoluciónReclamoDTO
            {
                Destinatario = "usuario@ejemplo.com",
                NombreSubasta = "Subasta Tecnología Segura",
                Resolución = "Tu reclamo fue aceptado y se procederá al reembolso del pago."
            };

            var command = new EnviarCorreoUsuarioResolucionReclamoCommand(dto);

            Assert.NotNull(command.reclamoDto);
            Assert.Equal("usuario@ejemplo.com", command.reclamoDto.Destinatario);
            Assert.Equal("Subasta Tecnología Segura", command.reclamoDto.NombreSubasta);
            Assert.Equal("Tu reclamo fue aceptado y se procederá al reembolso del pago.", command.reclamoDto.Resolución);
        }

    }
}
