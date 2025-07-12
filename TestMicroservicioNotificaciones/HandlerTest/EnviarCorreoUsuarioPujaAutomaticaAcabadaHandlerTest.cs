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
    public class EnviarCorreoUsuarioPujaAutomaticaAcabadaHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldSendEmailSuccessfully()
        {
            var mockSender = new Mock<IEmailSender>();
            mockSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .Returns(Task.CompletedTask);

            var handler = new EnviarCorreoUsuarioPujaAutomaticaAcabadaHandler(mockSender.Object);

            var dto = new CorreoUsuarioPujaAutomaticaAcabadaDTO
            {
                NombreProducto = "Robot de cocina inteligente",
                NombreSubasta = "Subasta Electrodomésticos Premium",
                MontoMaximo = 350.00m,
                Destinatario = "usuario@ejemplo.com"
            };

            var command = new EnviarCorreoUsuarioPujaAutomaticaAcabadaCommand(dto);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result);
            mockSender.Verify(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenEmailFails_ShouldThrowFalloAlEnviarCorreoException()
        {
            var mockSender = new Mock<IEmailSender>();
            mockSender
                .Setup(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()))
                .ThrowsAsync(new System.Exception("SMTP error"));

            var handler = new EnviarCorreoUsuarioPujaAutomaticaAcabadaHandler(mockSender.Object);

            var dto = new CorreoUsuarioPujaAutomaticaAcabadaDTO
            {
                NombreProducto = "Robot de cocina inteligente",
                NombreSubasta = "Subasta Electrodomésticos Premium",
                MontoMaximo = 350.00m,
                Destinatario = "usuario@ejemplo.com"
            };

            var command = new EnviarCorreoUsuarioPujaAutomaticaAcabadaCommand(dto);

            var ex = await Assert.ThrowsAsync<FalloAlEnviarCorreoException>(() => handler.Handle(command, CancellationToken.None));

            Assert.Contains("Ha ocurrido un error al enviar el correo al subastador", ex.Message);
            mockSender.Verify(sender => sender.SendEmailAsync(It.IsAny<Notificacion>()), Times.Once);
        }

    }
}
