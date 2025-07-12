using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;

namespace TestMicroservicioNotificaciones.CommandTest
{
    public class EnviarCorreoSubastadorReclamoPremioCommandTest
    {
        [Fact]
        public void Constructor_ShouldAssignReclamoPremioDTO()
        {
            var dto = new CorreoReclamoPremioDTO
            {
                CorreoUsuario = "ganador@ejemplo.com",
                NombreProducto = "Auriculares Inalámbricos XYZ",
                NombreSubasta = "Subasta Audio Premium"
            };

            var command = new EnviarCorreoSubastadorReclamoPremioCommand(dto);

            Assert.NotNull(command.ReclamoPremioDto);
            Assert.Equal("ganador@ejemplo.com", command.ReclamoPremioDto.CorreoUsuario);
            Assert.Equal("Auriculares Inalámbricos XYZ", command.ReclamoPremioDto.NombreProducto);
            Assert.Equal("Subasta Audio Premium", command.ReclamoPremioDto.NombreSubasta);
        }

    }
}
