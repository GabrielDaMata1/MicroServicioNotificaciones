namespace Application.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string destinatario, string mensaje);
    }
}