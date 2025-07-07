using Application.Commands;
using Application.Interfaces;


namespace Application.Handler
{
    public class SendNotificationCommandHandler
    {
        private readonly IEmailSender _emailSender;

        public SendNotificationCommandHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task Handle(SendNotificationCommand command)
        {
            await _emailSender.SendEmailAsync(command.Destinatario, command.Mensaje);
        }
    }
}