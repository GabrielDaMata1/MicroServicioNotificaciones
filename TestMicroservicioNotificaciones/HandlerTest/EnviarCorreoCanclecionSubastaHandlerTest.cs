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
    public class EnviarCorreoCanclecionSubastaHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldSendEmailToUsuarioAndSubastadorSuccessfully()
        {
            var mockEmailSender = new Mock<IEmailSender>();
            mockEmailSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .Returns(Task.CompletedTask);

            var handler = new EnviarCorreoSubastaCanceladaHandler(mockEmailSender.Object);

            var dto = new CorreoSubastaCanceladaDTO
            {
                NombreProducto = "Smart TV Ultra HD",
                NombreSubasta = "Subasta Televisores Premium",
                CorreoUsuario = "comprador@ejemplo.com",
                CorreoSubastador = "vendedor@ejemplo.com"
            };

            var command = new EnviarCorreoCancelacionSubastaCommand(dto);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result);
            mockEmailSender.Verify(s => s.SendEmailAsync(It.IsAny<Notificacion>()), Times.Exactly(2));
        }

        [Fact]
        public async Task Handle_WhenEmailSenderFails_ShouldThrowFalloAlEnviarCorreoException()
        {
            var mockEmailSender = new Mock<IEmailSender>();
            mockEmailSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .ThrowsAsync(new System.Exception("SMTP failed"));

            var handler = new EnviarCorreoSubastaCanceladaHandler(mockEmailSender.Object);

            var dto = new CorreoSubastaCanceladaDTO
            {
                NombreProducto = "Smart TV Ultra HD",
                NombreSubasta = "Subasta Televisores Premium",
                CorreoUsuario = "comprador@ejemplo.com",
                CorreoSubastador = "vendedor@ejemplo.com"
            };

            var command = new EnviarCorreoCancelacionSubastaCommand(dto);

            var ex = await Assert.ThrowsAsync<FalloAlEnviarCorreoException>(() => handler.Handle(command, CancellationToken.None));
            Assert.Contains("Ha ocurrido un error al enviar el correo al subastador", ex.Message);
            mockEmailSender.Verify(s => s.SendEmailAsync(It.IsAny<Notificacion>()), Times.AtLeastOnce);
        }

    }
}
