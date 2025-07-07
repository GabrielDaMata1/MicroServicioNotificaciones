using Microsoft.AspNetCore.Mvc;
using Application.Commands;
using Application.Handler;
using Application.DTO;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly SendNotificationCommandHandler _handler;

    public NotificationController(SendNotificationCommandHandler handler)
    {
        _handler = handler;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] SendNotificationDto dto)
    {
        var command = new SendNotificationCommand(dto.Destinatario, dto.Mensaje);
        await _handler.Handle(command);
        return Ok("Correo enviado");
    }
}
