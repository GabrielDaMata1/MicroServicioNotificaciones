namespace Application.DTO
{
    public class SendNotificationDto
    {
        public required string Destinatario { get; set; }
        public required string Mensaje { get; set; }
    }
}