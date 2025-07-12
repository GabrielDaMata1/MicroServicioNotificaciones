using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;

namespace TestMicroservicioNotificaciones.CommandTest
{
    public class EnviarCorreoCancelacionSubastaCommandTest
    {
        [Fact]
        public void Constructor_ShouldAssignSubastaDTO()
        {
            var dto = new CorreoSubastaCanceladaDTO
            {
                NombreProducto = "PlayStation 5",
                NombreSubasta = "PS5 Premium Subasta",
                CorreoUsuario = "comprador@ejemplo.com",
                CorreoSubastador = "vendedor@ejemplo.com"
            };

            var command = new EnviarCorreoCancelacionSubastaCommand(dto);

            Assert.Equal(dto, command.subastaDTO);
            Assert.Equal("PlayStation 5", command.subastaDTO.NombreProducto);
            Assert.Equal("PS5 Premium Subasta", command.subastaDTO.NombreSubasta);
            Assert.Equal("comprador@ejemplo.com", command.subastaDTO.CorreoUsuario);
            Assert.Equal("vendedor@ejemplo.com", command.subastaDTO.CorreoSubastador);
        }

    }
}
