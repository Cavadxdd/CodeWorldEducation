using Microsoft.Extensions.DependencyInjection;
using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Infrastructure.Services;

namespace CodeWorldEducation.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IAnnouncementService, AnnouncementService>();
        services.AddScoped<IEventService, EventService>();

        return services;
    }
}