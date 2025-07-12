using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;

namespace TestMicroservicioNotificaciones.CommandTest
{
    public class EnviarCorreoGanadorSubastaCommandTest
    {
        [Fact]
        public void Constructor_ShouldAssignCorreoDTO()
        {
            var dto = new CorreoGanadorSubastaDTO
            {
                Destinatario = "ganador@ejemplo.com",
                NombreSubasta = "Subasta Tecnología Premium",
                NombreProducto = "Laptop Alienware",
                MontoGanador = 1299.99m
            };

            var command = new EnviarCorreoGanadorSubastaCommand(dto);

            Assert.NotNull(command.correoDTO);
            Assert.Equal("ganador@ejemplo.com", command.correoDTO.Destinatario);
            Assert.Equal("Subasta Tecnología Premium", command.correoDTO.NombreSubasta);
            Assert.Equal("Laptop Alienware", command.correoDTO.NombreProducto);
            Assert.Equal(1299.99m, command.correoDTO.MontoGanador);
        }


    }
}
