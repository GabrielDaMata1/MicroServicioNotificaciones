using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;

namespace TestMicroservicioNotificaciones.CommandTest
{
    public class EnviarCorreoUsuarioPagoSubastaCommandTest
    {
        [Fact]
        public void Constructor_ShouldAssignPagoDTO()
        {
            var dto = new CorreoUsuarioPagoSubastaDTO
            {
                CorreoUsuario = "usuario@ejemplo.com",
                NombreSubasta = "Subasta Fotografía Avanzada",
                MontoPago = 749.99m
            };

            var command = new EnviarCorreoUsuarioPagoSubastaCommand(dto);

            Assert.NotNull(command.pagoDto);
            Assert.Equal("usuario@ejemplo.com", command.pagoDto.CorreoUsuario);
            Assert.Equal("Subasta Fotografía Avanzada", command.pagoDto.NombreSubasta);
            Assert.Equal(749.99m, command.pagoDto.MontoPago);
        }


    }
}
