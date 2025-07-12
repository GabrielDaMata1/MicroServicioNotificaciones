using Microsoft.AspNetCore.Mvc;
using Application.Commands;
using Application.Handler;
using Application.DTO;
using Application.DTOs;
using MediatR;
/// <summary>
/// Clase controller API encargada de procesar las solicitudes de envío de notificaciones mediante correo electrónico por parte de otros Microservicios </summary>
[ApiController]
[Route("api/[controller]")]

public class NotificationController : ControllerBase

{
    /// <summary>
    /// Atributo que se encarga de enviar solicitudes (commands/queries) mediante el patrón mediador
    /// </summary>
    private readonly IMediator _mediator;
    public NotificationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// Endpoint encargado de enviar una notificacion al usuario ganador de una subasta cuando esta finaliza.
    /// </summary>
    /// <param name="usuarioGanadorDto">Parametro de tipo DTO con los datos del usuario ganador.</param>
    /// <returns>Resultado de la operación con mensaje y estado dependiendo del resultado.</returns>

    [HttpPost("enviarNotificacionUsuarioGanadorSubasta")]
    public async Task<IActionResult> EnviarNotificacionUsuarioGanadorSubasta([FromBody] CorreoGanadorSubastaDTO usuarioGanadorDto)
    {
        var resultado = await _mediator.Send(new EnviarCorreoGanadorSubastaCommand(usuarioGanadorDto));
        if (resultado)
        {
            return Ok(new ResultadoDTO { Mensaje = "El correo ha sido enviado exitosamente al usuario .", Exito = true });
        }

        return BadRequest(new ResultadoDTO { Mensaje = "El correo no puedo ser enviado exitosamente .", Exito = false });
    }
    /// <summary>
    /// Endpoint encargado de enviar una notificacion al subastador de una subasta cuando esta finaliza.
    /// </summary>
    /// <param name="subastadorDto">Parametro de tipo DTO con los datos del usuario ganador y el correo del subastador.</param>
    /// <returns>Resultado de la operación con mensaje y estado dependiendo del resultado.</returns>
    [HttpPost("enviarNotificacionSubastadorSubastaFinalizada")]
    public async Task<IActionResult> EnviarNotificacionSubastadorSubastaFinalizada([FromBody] CorreoSubastadorSubastaFinalizadaDTO subastadorDto)
    {
        var resultado = await _mediator.Send(new EnviarCorreoSubastadorSubastaFinalizadaCommand(subastadorDto));
        if (resultado)
        {
            return Ok(new ResultadoDTO { Mensaje = "El correo ha sido enviado exitosamente al subastador .", Exito = true });
        }

        return BadRequest(new ResultadoDTO { Mensaje = "El correo no puedo ser enviado exitosamente .", Exito = false });
    }

    /// <summary>
    /// Endpoint encargado de enviar una notificacion al subastador cuando recibe un pagode una subasta.
    /// </summary>
    /// <param name="pagoDto">Parametro de tipo DTO con los datos del usuario, datos de la subasta y el monto del pago recibido.</param>
    /// <returns>Resultado de la operación con mensaje y estado dependiendo del resultado.</returns>
    [HttpPost("enviarCorreoSubastadorPagoSubasta")]
    public async Task<IActionResult> EnviarCorreoSubastadorPagoSubasta([FromBody] CorreoUsuarioPagoSubastaDTO pagoDto)
    {
        var resultado = await _mediator.Send(new EnviarCorreoUsuarioPagoSubastaCommand(pagoDto));
        if (resultado)
        {
            return Ok(new ResultadoDTO { Mensaje = "El correo ha sido enviado exitosamente al subastador .", Exito = true });
        }

        return BadRequest(new ResultadoDTO { Mensaje = "El correo no puedo ser enviado exitosamente .", Exito = false });
    }

    /// <summary>
    /// Endpoint encargado de enviar una notificacion al subastador cuando recibe un pagode una subasta.
    /// </summary>
    /// <param name="pagoDto">Parametro de tipo DTO con los datos del usuario, datos de la subasta y el monto del pago recibido.</param>
    /// <returns>Resultado de la operación con mensaje y estado dependiendo del resultado.</returns>
    [HttpPost("enviarCorreoUsuarioPagoFallidoSubasta")]
    public async Task<IActionResult> EnviarCorreoUsuarioPagoFallidoSubasta([FromBody] CorreoUsuarioPagoSubastaFallidoDTO pagoFallidoDto)
    {
        var resultado = await _mediator.Send(new EnviarCorreoPagoSubastaFallidoCommand(pagoFallidoDto));
        if (resultado)
        {
            return Ok(new ResultadoDTO { Mensaje = "El correo ha sido enviado exitosamente al usuario .", Exito = true });
        }

        return BadRequest(new ResultadoDTO { Mensaje = "El correo no puedo ser enviado exitosamente .", Exito = false });
    }

    /// <summary>
    /// Endpoint encargado de enviar una notificacion al usuario que le indique que ya su puja automática ha llegado a su límite.
    /// </summary>
    /// <param name="usuarioPujaAutomaticaAcabadaDto">Parametro de tipo DTO con los datos del usuario, datos de la subasta y el monto maximo de la puja automática.</param>
    /// <returns>Resultado de la operación con mensaje y estado dependiendo del resultado.</returns>
    [HttpPost("enviarCorreoUsuarioPujaAutomaticaAcabada")]
    public async Task<IActionResult> EnviarCorreoUsuarioPujaAutomaticaAcabada([FromBody] CorreoUsuarioPujaAutomaticaAcabadaDTO usuarioPujaAutomaticaAcabadaDto)
    {
        var resultado = await _mediator.Send(new EnviarCorreoUsuarioPujaAutomaticaAcabadaCommand(usuarioPujaAutomaticaAcabadaDto));
        if (resultado)
        {
            return Ok(new ResultadoDTO { Mensaje = "El correo ha sido enviado exitosamente al usuario .", Exito = true });
        }

        return BadRequest(new ResultadoDTO { Mensaje = "El correo no puedo ser enviado exitosamente .", Exito = false });
    }

    /// <summary>
    /// Endpoint encargado de enviar una notificacion al usuario una vez su reclamo de una subasta ha sido atendido.
    /// </summary>
    /// <param name="resolucionDto">Parametro de tipo DTO con los datos del usuario, datos de la subasta y la resolucion del reclamo.</param>
    /// <returns>Resultado de la operación con mensaje y estado dependiendo del resultado.</returns>
    [HttpPost("enviarCorreoUsuarioResolucionReclamo")]
    public async Task<IActionResult> EnviarCorreoUsuarioResolucionReclamo([FromBody] CorreoUsuarioResoluciónReclamoDTO resolucionDto)
    {
        var resultado = await _mediator.Send(new EnviarCorreoUsuarioResolucionReclamoCommand(resolucionDto));
        if (resultado)
        {
            return Ok(new ResultadoDTO { Mensaje = "El correo ha sido enviado exitosamente al usuario .", Exito = true });
        }

        return BadRequest(new ResultadoDTO { Mensaje = "El correo no puedo ser enviado exitosamente .", Exito = false });
    }

    /// <summary>
    /// Endpoint encargado de enviar una notificacion al subastador cuando un usuario reclama su premio de una subasta.
    /// </summary>
    /// <param name="reclamoDto">Parametro de tipo DTO con los datos del usuario y datos de la subasta.</param>
    /// <returns>Resultado de la operación con mensaje y estado dependiendo del resultado.</returns>
    [HttpPost("enviarCorreoSubastadorReclamoPremio")]
    public async Task<IActionResult> EnviarCorreoSubastadorReclamoPremio([FromBody] CorreoReclamoPremioDTO reclamoDto)
    {
        var resultado = await _mediator.Send(new EnviarCorreoSubastadorReclamoPremioCommand(reclamoDto));
        if (resultado)
        {
            return Ok(new ResultadoDTO { Mensaje = "El correo ha sido enviado exitosamente al subastador .", Exito = true });
        }

        return BadRequest(new ResultadoDTO { Mensaje = "El correo no puedo ser enviado exitosamente .", Exito = false });
    }

    /// <summary>
    /// Endpoint encargado de enviar una notificacion al subastador cuando un usuario confirma su reclamo de premio de una subasta.
    /// </summary>
    /// <param name="confirmacionReclamoDto">Parametro de tipo DTO con los datos del usuario y datos de la subasta.</param>
    /// <returns>Resultado de la operación con mensaje y estado dependiendo del resultado.</returns>
    [HttpPost("enviarCorreoSubastadorConfirmacionReclamoPremio")]
    public async Task<IActionResult> EnviarCorreoSubastadorConfirmacionReclamoPremio([FromBody] CorreoReclamoPremioDTO confirmacionReclamoDto)
    {
        var resultado = await _mediator.Send(new EnviarCorreoSubastadorConfirmacionReclamoPremioCommand(confirmacionReclamoDto));
        if (resultado)
        {
            return Ok(new ResultadoDTO { Mensaje = "El correo ha sido enviado exitosamente al subastador .", Exito = true });
        }

        return BadRequest(new ResultadoDTO { Mensaje = "El correo no puedo ser enviado exitosamente .", Exito = false });
    }

    /// <summary>
    /// Endpoint encargado de enviar una notificacion al subastador y al usuario ganador cuando una subasta es cancelada por falta de pago.
    /// </summary>
    /// <param name="subastaCanceladaDto">Parametro de tipo DTO con el correo del usuario, datos de la subasta y correo del subastador.</param>
    /// <returns>Resultado de la operación con mensaje y estado dependiendo del resultado.</returns>
    [HttpPost("enviarCorreoUsuariosSubastaCancelada")]
    public async Task<IActionResult> EnviarCorreoUsuariosSubastaCancelada([FromBody] CorreoSubastaCanceladaDTO subastaCanceladaDto)
    {
        var resultado = await _mediator.Send(new EnviarCorreoCancelacionSubastaCommand(subastaCanceladaDto));
        if (resultado)
        {
            return Ok(new ResultadoDTO { Mensaje = "El correo ha sido enviado exitosamente al subastador y al usuario .", Exito = true });
        }

        return BadRequest(new ResultadoDTO { Mensaje = "El correo no puedo ser enviado exitosamente .", Exito = false });
    }
}
