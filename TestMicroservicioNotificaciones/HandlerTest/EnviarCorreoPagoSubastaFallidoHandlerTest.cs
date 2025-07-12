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
    public class EnviarCorreoPagoSubastaFallidoHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldSendEmailSuccessfully()
        {
            var mockEmailSender = new Mock<IEmailSender>();
            mockEmailSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .Returns(Task.CompletedTask);

            var handler = new EnviarCorreoPagoSubastaFallidoHandler(mockEmailSender.Object);

            var command = new EnviarCorreoPagoSubastaFallidoCommand(new CorreoUsuarioPagoSubastaFallidoDTO
            {
                Destinatario = "usuario@ejemplo.com",
                NombreSubasta = "Subasta Gaming 2025",
                MontoPago = 499.99m
            });

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result);
            mockEmailSender.Verify(s => s.SendEmailAsync(It.IsAny<Notificacion>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenEmailSenderFails_ShouldThrowFalloAlEnviarCorreoException()
        {
            var mockEmailSender = new Mock<IEmailSender>();
            mockEmailSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .ThrowsAsync(new System.Exception("SMTP failure"));

            var handler = new EnviarCorreoPagoSubastaFallidoHandler(mockEmailSender.Object);

            var command = new EnviarCorreoPagoSubastaFallidoCommand(new CorreoUsuarioPagoSubastaFallidoDTO
            {
                Destinatario = "usuario@ejemplo.com",
                NombreSubasta = "Subasta Gaming 2025",
                MontoPago = 499.99m
            });

            var ex = await Assert.ThrowsAsync<FalloAlEnviarCorreoException>(() => handler.Handle(command, CancellationToken.None));

            Assert.Contains("Ha ocurrido un error al enviar el correo al subastador", ex.Message);
            mockEmailSender.Verify(s => s.SendEmailAsync(It.IsAny<Notificacion>()), Times.Once);
        }

    }
}
