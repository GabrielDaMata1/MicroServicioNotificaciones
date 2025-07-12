using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;

namespace TestMicroservicioNotificaciones.CommandTest
{
    public class EnviarCorreoSubastadorConfirmacionReclamoPremioCommandTest
    {
        [Fact]
        public void Constructor_ShouldAssignReclamoPremioDTO()
        {
            var dto = new CorreoReclamoPremioDTO
            {
                CorreoUsuario = "ganador@ejemplo.com",
                NombreProducto = "Televisor OLED 65 pulgadas",
                NombreSubasta = "Subasta SmartTech 2025"
            };

            var command = new EnviarCorreoSubastadorConfirmacionReclamoPremioCommand(dto);

            Assert.NotNull(command.reclamoPremioDto);
            Assert.Equal("ganador@ejemplo.com", command.reclamoPremioDto.CorreoUsuario);
            Assert.Equal("Televisor OLED 65 pulgadas", command.reclamoPremioDto.NombreProducto);
            Assert.Equal("Subasta SmartTech 2025", command.reclamoPremioDto.NombreSubasta);
        }

    }
}
