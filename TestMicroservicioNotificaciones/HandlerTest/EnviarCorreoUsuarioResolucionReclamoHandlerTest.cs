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
    public class EnviarCorreoUsuarioResolucionReclamoHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldSendEmailSuccessfully()
        {
            var mockSender = new Mock<IEmailSender>();
            mockSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .Returns(Task.CompletedTask);

            var handler = new EnviarCorreoUsuarioResolucionReclamoHandler(mockSender.Object);

            var dto = new CorreoUsuarioResoluciónReclamoDTO
            {
                NombreSubasta = "Subasta Smartphones",
                Resolución = "Tu reclamo fue aceptado. Se reembolsará el monto abonado.",
                Destinatario = "usuario@ejemplo.com"
            };

            var command = new EnviarCorreoUsuarioResolucionReclamoCommand(dto);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result);
            mockSender.Verify(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenEmailSendingFails_ShouldThrowFalloAlEnviarCorreoException()
        {
            var mockSender = new Mock<IEmailSender>();
            mockSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .ThrowsAsync(new System.Exception("SMTP error"));

            var handler = new EnviarCorreoUsuarioResolucionReclamoHandler(mockSender.Object);

            var dto = new CorreoUsuarioResoluciónReclamoDTO
            {
                NombreSubasta = "Subasta Smartphones",
                Resolución = "Tu reclamo fue rechazado por falta de evidencias.",
                Destinatario = "usuario@ejemplo.com"
            };

            var command = new EnviarCorreoUsuarioResolucionReclamoCommand(dto);

            var ex = await Assert.ThrowsAsync<FalloAlEnviarCorreoException>(() => handler.Handle(command, CancellationToken.None));

            Assert.Contains("Ha ocurrido un error al enviar el correo al subastador", ex.Message);
            mockSender.Verify(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()), Times.Once);
        }

    }
}
