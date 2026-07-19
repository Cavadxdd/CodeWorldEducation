using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Repositories;
using CodeWorldEducation.Application.UnitOfWorks;
using CodeWorldEducation.Domain.Entities;
using CodeWorldEducation.Persistence.Contexts;
using CodeWorldEducation.Persistence.Implementations;
using CodeWorldEducation.Persistence.Repositories;
using CodeWorldEducation.Persistence.Services;
using CodeWorldEducation.Persistence.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace CodeWorldEducation.Persistence;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionStringName = configuration.GetConnectionString("DefaultConnection");

        var connectionString = Environment.GetEnvironmentVariable(connectionStringName!)
                               ?? throw new InvalidOperationException(
                                   $"Environment variable '{connectionStringName}' was not found.");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IMentorRepository, MentorRepository>();
        services.AddScoped<IAlumniRepository, AlumniRepository>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddScoped<IMentorService, MentorService>();
        services.AddScoped<IAlumniService, AlumniService>();
        services.AddScoped<IEndpointService, EndpointService>();
        services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();

        return services;
    }
}