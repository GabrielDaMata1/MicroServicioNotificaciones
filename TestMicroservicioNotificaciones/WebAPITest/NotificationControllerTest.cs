using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestMicroservicioNotificaciones.WebAPITest
{
    public class NotificationControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly NotificationController _controller;

        public NotificationControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new NotificationController(_mediatorMock.Object);
        }

        [Fact]
        public async Task EnviarNotificacionUsuarioGanadorSubasta_ShouldReturnOk_WhenEmailSent()
        {
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<EnviarCorreoGanadorSubastaCommand>(), default))
                .ReturnsAsync(true);

            var dto = new CorreoGanadorSubastaDTO();
            var result = await _controller.EnviarNotificacionUsuarioGanadorSubasta(dto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ResultadoDTO>(okResult.Value);
            Assert.True(response.Exito);
        }

        [Fact]
        public async Task EnviarNotificacionUsuarioGanadorSubasta_ShouldReturnBadRequest_WhenEmailFails()
        {
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<EnviarCorreoGanadorSubastaCommand>(), default))
                .ReturnsAsync(false);

            var dto = new CorreoGanadorSubastaDTO();
            var result = await _controller.EnviarNotificacionUsuarioGanadorSubasta(dto);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            var response = Assert.IsType<ResultadoDTO>(badRequest.Value);
            Assert.False(response.Exito);
        }

        [Theory]
        [InlineData(true, typeof(OkObjectResult))]
        [InlineData(false, typeof(BadRequestObjectResult))]
        public async Task EnviarCorreoUsuarioResolucionReclamo_ShouldReturnExpectedResult(bool success, Type expectedType)
        {
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<EnviarCorreoUsuarioResolucionReclamoCommand>(), default))
                .ReturnsAsync(success);

            var dto = new CorreoUsuarioResoluciónReclamoDTO();
            var result = await _controller.EnviarCorreoUsuarioResolucionReclamo(dto);

            Assert.IsType(expectedType, result);
        }

        [Theory]
        [InlineData(true, typeof(OkObjectResult))]
        [InlineData(false, typeof(BadRequestObjectResult))]
        public async Task EnviarNotificacionSubastadorSubastaFinalizada_ShouldReturnExpectedResult(bool success, Type expectedType)
        {
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<EnviarCorreoSubastadorSubastaFinalizadaCommand>(), default))
                .ReturnsAsync(success);

            var dto = new CorreoSubastadorSubastaFinalizadaDTO();
            var result = await _controller.EnviarNotificacionSubastadorSubastaFinalizada(dto);

            Assert.IsType(expectedType, result);
        }

        [Theory]
        [InlineData(true, typeof(OkObjectResult))]
        [InlineData(false, typeof(BadRequestObjectResult))]
        public async Task EnviarCorreoSubastadorPagoSubasta_ShouldReturnExpectedResult(bool success, Type expectedType)
        {
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<EnviarCorreoUsuarioPagoSubastaCommand>(), default))
                .ReturnsAsync(success);

            var dto = new CorreoUsuarioPagoSubastaDTO();
            var result = await _controller.EnviarCorreoSubastadorPagoSubasta(dto);

            Assert.IsType(expectedType, result);
        }

        [Theory]
        [InlineData(true, typeof(OkObjectResult))]
        [InlineData(false, typeof(BadRequestObjectResult))]
        public async Task EnviarCorreoUsuarioPagoFallidoSubasta_ShouldReturnExpectedResult(bool success, Type expectedType)
        {
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<EnviarCorreoPagoSubastaFallidoCommand>(), default))
                .ReturnsAsync(success);

            var dto = new CorreoUsuarioPagoSubastaFallidoDTO();
            var result = await _controller.EnviarCorreoUsuarioPagoFallidoSubasta(dto);

            Assert.IsType(expectedType, result);
        }

        [Theory]
        [InlineData(true, typeof(OkObjectResult))]
        [InlineData(false, typeof(BadRequestObjectResult))]
        public async Task EnviarCorreoUsuarioPujaAutomaticaAcabada_ShouldReturnExpectedResult(bool success, Type expectedType)
        {
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<EnviarCorreoUsuarioPujaAutomaticaAcabadaCommand>(), default))
                .ReturnsAsync(success);

            var dto = new CorreoUsuarioPujaAutomaticaAcabadaDTO();
            var result = await _controller.EnviarCorreoUsuarioPujaAutomaticaAcabada(dto);

            Assert.IsType(expectedType, result);
        }

        [Theory]
        [InlineData(true, typeof(OkObjectResult))]
        [InlineData(false, typeof(BadRequestObjectResult))]
        public async Task EnviarCorreoSubastadorReclamoPremio_ShouldReturnExpectedResult(bool success, Type expectedType)
        {
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<EnviarCorreoSubastadorReclamoPremioCommand>(), default))
                .ReturnsAsync(success);

            var dto = new CorreoReclamoPremioDTO();
            var result = await _controller.EnviarCorreoSubastadorReclamoPremio(dto);

            Assert.IsType(expectedType, result);
        }

        [Theory]
        [InlineData(true, typeof(OkObjectResult))]
        [InlineData(false, typeof(BadRequestObjectResult))]
        public async Task EnviarCorreoSubastadorConfirmacionReclamoPremio_ShouldReturnExpectedResult(bool success, Type expectedType)
        {
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<EnviarCorreoSubastadorConfirmacionReclamoPremioCommand>(), default))
                .ReturnsAsync(success);

            var dto = new CorreoReclamoPremioDTO();
            var result = await _controller.EnviarCorreoSubastadorConfirmacionReclamoPremio(dto);

            Assert.IsType(expectedType, result);
        }

    }
}
