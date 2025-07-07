namespace Application.Commands
{
    public class SendNotificationCommand
    {
        public string Destinatario { get; }
        public string Mensaje { get; }

        public SendNotificationCommand(string destinatario, string mensaje)
        {
            Destinatario = destinatario;
            Mensaje = mensaje;
        }
    }
}