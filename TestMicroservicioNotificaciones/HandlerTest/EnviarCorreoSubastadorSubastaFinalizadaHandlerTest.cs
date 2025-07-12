using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Handler;
using Application.Interfaces;
using Domain.Entities;
using Moq;

namespace TestMicroservicioNotificaciones.HandlerTest
{
    public class EnviarCorreoSubastadorSubastaFinalizadaHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldSendEmailSuccessfully()
        {
            var mockEmailSender = new Mock<IEmailSender>();
            mockEmailSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .Returns(Task.CompletedTask);

            var handler = new EnviarCorreoSubastadorSubastaFinalizadaHandler(mockEmailSender.Object);

            var dto = new CorreoSubastadorSubastaFinalizadaDTO
            {
                NombreProducto = "Monitor UltraWide LG",
                NombreSubasta = "Subasta Pantallas Gaming",
                CorreoGanador = "ganador@ejemplo.com",
                MontoGanador = 799.99m,
                Destinatario = "subastador@ejemplo.com"
            };

            var command = new EnviarCorreoSubastadorSubastaFinalizadaCommand(dto);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result);
            mockEmailSender.Verify(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenEmailSendingFails_ShouldThrowFalloAlEnviarCorreoException()
        {
            var mockEmailSender = new Mock<IEmailSender>();
            mockEmailSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .ThrowsAsync(new System.Exception("SMTP failure"));

            var handler = new EnviarCorreoSubastadorSubastaFinalizadaHandler(mockEmailSender.Object);

            var dto = new CorreoSubastadorSubastaFinalizadaDTO
            {
                NombreProducto = "Monitor UltraWide LG",
                NombreSubasta = "Subasta Pantallas Gaming",
                CorreoGanador = "ganador@ejemplo.com",
                MontoGanador = 799.99m,
                Destinatario = "subastador@ejemplo.com"
            };

            var command = new EnviarCorreoSubastadorSubastaFinalizadaCommand(dto);

            var ex = await Assert.ThrowsAsync<FalloAlEnviarCorreoException>(() => handler.Handle(command, CancellationToken.None));

            Assert.Contains("Ha ocurrido un error al enviar el correo al subastador", ex.Message);
            mockEmailSender.Verify(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()), Times.Once);
        }

    }
}
