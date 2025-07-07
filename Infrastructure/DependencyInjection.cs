using Microsoft.Extensions.DependencyInjection;
using Application.Handler;
using Application.Interfaces;
using Infrastructure.Email;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, SmtpEmailSender>();
        services.AddScoped<SendNotificationCommandHandler>();

        return services;
    }
}
