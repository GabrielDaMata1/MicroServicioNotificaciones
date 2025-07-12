using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;

namespace TestMicroservicioNotificaciones.CommandTest
{
    public class EnviarCorreoPagoSubastaFallidoCommandTest
    {
        [Fact]
        public void Constructor_ShouldAssignPagoDTOCorrectly()
        {
            var dto = new CorreoUsuarioPagoSubastaFallidoDTO
            {
                Destinatario = "usuario@ejemplo.com",
                NombreSubasta = "Subasta Plegables 2025",
                MontoPago = 1950.00m
            };

            var command = new EnviarCorreoPagoSubastaFallidoCommand(dto);

            Assert.NotNull(command.pagoDTO);
            Assert.Equal("usuario@ejemplo.com", command.pagoDTO.Destinatario);
            Assert.Equal("Subasta Plegables 2025", command.pagoDTO.NombreSubasta);
            Assert.Equal(1950.00m, command.pagoDTO.MontoPago);
        }

    }
}
