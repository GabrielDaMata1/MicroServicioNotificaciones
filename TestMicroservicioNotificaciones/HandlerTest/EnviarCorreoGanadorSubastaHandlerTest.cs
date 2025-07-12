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
    public class EnviarCorreoGanadorSubastaHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldSendEmailSuccessfully()
        {
            var mockEmailSender = new Mock<IEmailSender>();
            mockEmailSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .Returns(Task.CompletedTask);

            var handler = new EnviarCorreoGanadorSubastaHandler(mockEmailSender.Object);

            var command = new EnviarCorreoGanadorSubastaCommand(new CorreoGanadorSubastaDTO
            {
                Destinatario = "ganador@ejemplo.com",
                NombreProducto = "Notebook Lenovo X1",
                NombreSubasta = "Subasta Computadoras Premium",
                MontoGanador = 1050.75m
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
                .ThrowsAsync(new System.Exception("SMTP error"));

            var handler = new EnviarCorreoGanadorSubastaHandler(mockEmailSender.Object);

            var command = new EnviarCorreoGanadorSubastaCommand(new CorreoGanadorSubastaDTO
            {
                Destinatario = "ganador@ejemplo.com",
                NombreProducto = "Notebook Lenovo X1",
                NombreSubasta = "Subasta Computadoras Premium",
                MontoGanador = 1050.75m
            });

            var ex = await Assert.ThrowsAsync<FalloAlEnviarCorreoException>(() => handler.Handle(command, CancellationToken.None));

            Assert.Contains("Ha ocurrido un error al enviar el correo al usuario", ex.Message);
            mockEmailSender.Verify(s => s.SendEmailAsync(It.IsAny<Notificacion>()), Times.Once);
        }

    }
}
