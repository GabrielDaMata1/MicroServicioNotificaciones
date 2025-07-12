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
    public class EnviarCorreoUsuarioPagoSubastaHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldSendEmailSuccessfully()
        {
            var mockEmailSender = new Mock<IEmailSender>();
            mockEmailSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .Returns(Task.CompletedTask);

            var handler = new EnviarCorreoUsuarioPagoSubastaHandler(mockEmailSender.Object);

            var dto = new CorreoUsuarioPagoSubastaDTO
            {
                NombreSubasta = "Subasta Fotografía 2025",
                MontoPago = 1249.50m,
                CorreoUsuario = "ganador@ejemplo.com",
                Destinatario = "subastador@ejemplo.com"
            };

            var command = new EnviarCorreoUsuarioPagoSubastaCommand(dto);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result);
            mockEmailSender.Verify(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenEmailSenderThrows_ShouldThrowFalloAlEnviarCorreoException()
        {
            var mockEmailSender = new Mock<IEmailSender>();
            mockEmailSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .ThrowsAsync(new System.Exception("SMTP error"));

            var handler = new EnviarCorreoUsuarioPagoSubastaHandler(mockEmailSender.Object);

            var dto = new CorreoUsuarioPagoSubastaDTO
            {
                NombreSubasta = "Subasta Fotografía 2025",
                MontoPago = 1249.50m,
                CorreoUsuario = "ganador@ejemplo.com",
                Destinatario = "subastador@ejemplo.com"
            };

            var command = new EnviarCorreoUsuarioPagoSubastaCommand(dto);

            var ex = await Assert.ThrowsAsync<FalloAlEnviarCorreoException>(() => handler.Handle(command, CancellationToken.None));

            Assert.Contains("Ha ocurrido un error al enviar el correo al subastador", ex.Message);
            mockEmailSender.Verify(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()), Times.Once);
        }

    }
}
