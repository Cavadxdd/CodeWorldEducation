using CodeWorldEducation.API.Middlewares;
using CodeWorldEducation.Application;
using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Security;
using CodeWorldEducation.Infrastructure;
using CodeWorldEducation.Persistence;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Serilog;

Env.TraversePath().Load();
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CodeWorldEducation API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header. Example: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Layer Registration
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var jwtSecret = Environment.GetEnvironmentVariable(
    builder.Configuration["Jwt:Secret"]!)
    ?? throw new InvalidOperationException("JWT_SECRET environment variable not found.");

var jwtIssuer = Environment.GetEnvironmentVariable(
    builder.Configuration["Jwt:Issuer"]!)
    ?? throw new InvalidOperationException("JWT_ISSUER environment variable not found.");

var jwtAudience = Environment.GetEnvironmentVariable(
    builder.Configuration["Jwt:Audience"]!)
    ?? throw new InvalidOperationException("JWT_AUDIENCE environment variable not found.");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSecret))
    };
});
// NOT: Bu bloklar əvvəllər ikinci bir JWT qeydiyyatı yaradırdı və
// "Scheme already exists: Bearer" xətasına səbəb olurdu, ona görə deaktiv edilib.
//// JWT Config
//var secret = builder.Configuration["Jwt:Secret"];
//var issuer = builder.Configuration["Jwt:Issuer"];
//var audience = builder.Configuration["Jwt:Audience"];

//if (string.IsNullOrWhiteSpace(secret))
//    throw new Exception("Jwt:Secret tapılmadı.");

//if (string.IsNullOrWhiteSpace(issuer))
//    throw new Exception("Jwt:Issuer tapılmadı.");

//if (string.IsNullOrWhiteSpace(audience))
//    throw new Exception("Jwt:Audience tapılmadı.");

//builder.Services
//    .AddAuthentication(options =>
//    {
//        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//    })
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,

//            ValidIssuer = issuer,
//            ValidAudience = audience,

//            IssuerSigningKey = new SymmetricSecurityKey(
//                Encoding.UTF8.GetBytes(secret)),

//            ClockSkew = TimeSpan.Zero
//        };
//    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EndpointPermission", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.AddRequirements(new EndpointPermissionRequirement());
    });
});

builder.Services.AddScoped<IAuthorizationHandler, EndpointPermissionHandler>();

Console.WriteLine(builder.Configuration["GoogleMailSettings:ClientId"]);
Console.WriteLine(builder.Configuration["GoogleMailSettings:FromEmail"]);

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var endpointService = scope.ServiceProvider.GetRequiredService<IEndpointService>();

    await endpointService.RegisterEndpointsAsync(typeof(Program).Assembly);
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("CodeWorld API starting up");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "CodeWorld API failed to start");
}
finally
{
    Log.CloseAndFlush();
}
