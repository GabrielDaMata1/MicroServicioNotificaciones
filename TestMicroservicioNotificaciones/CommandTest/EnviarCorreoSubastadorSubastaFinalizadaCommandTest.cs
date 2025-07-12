using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;

namespace TestMicroservicioNotificaciones.CommandTest
{
    public class EnviarCorreoSubastadorSubastaFinalizadaCommandTest
    {
        [Fact]
        public void Constructor_ShouldAssignCorreoDTO()
        {
            var dto = new CorreoSubastadorSubastaFinalizadaDTO
            {
                Destinatario = "subastador@ejemplo.com",
                NombreProducto = "Tablet X500",
                NombreSubasta = "Subasta Tablets Premium",
                CorreoGanador = "ganador@ejemplo.com",
                MontoGanador = 899.50m
            };

            var command = new EnviarCorreoSubastadorSubastaFinalizadaCommand(dto);

            Assert.NotNull(command.correoDTO);
            Assert.Equal("ganador@ejemplo.com", command.correoDTO.CorreoGanador);
            Assert.Equal("Tablet X500", command.correoDTO.NombreProducto);
            Assert.Equal("Subasta Tablets Premium", command.correoDTO.NombreSubasta);
            Assert.Equal(899.50m, command.correoDTO.MontoGanador);
        }

    }
}
