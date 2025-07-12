using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;

namespace TestMicroservicioNotificaciones.CommandTest
{
    public class EnviarCorreoUsuarioPujaAutomaticaAcabadaCommandTest
    {
        [Fact]
        public void Constructor_ShouldAssignUsuarioDTO()
        {
            var dto = new CorreoUsuarioPujaAutomaticaAcabadaDTO
            {
                Destinatario = "usuario@ejemplo.com",
                NombreProducto = "Consola Retro",
                NombreSubasta = "Subasta Vintage Tech",
                MontoMaximo = 320.00m
            };

            var command = new EnviarCorreoUsuarioPujaAutomaticaAcabadaCommand(dto);

            Assert.NotNull(command.usuarioDTO);
            Assert.Equal("usuario@ejemplo.com", command.usuarioDTO.Destinatario);
            Assert.Equal("Consola Retro", command.usuarioDTO.NombreProducto);
            Assert.Equal("Subasta Vintage Tech", command.usuarioDTO.NombreSubasta);
            Assert.Equal(320.00m, command.usuarioDTO.MontoMaximo);
        }

    }
}
