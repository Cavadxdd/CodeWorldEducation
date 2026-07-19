using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodeWorldEducation.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
		services.AddScoped<IFileService, FileService>();
		services.AddScoped<IWhatsAppService, WhatsAppService>();
        services.AddScoped<IEmailService, EmailService>();

		return services;
    }
}