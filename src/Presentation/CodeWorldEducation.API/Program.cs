
//using CodeWorldEducation.Persistence.Contexts;

//using Microsoft.EntityFrameworkCore;
//using CodeWorldEducation.Infrastructure;
//using CodeWorldEducation.Application;


//using CodeWorldEducation.Persistence;


//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddControllers();


//builder.Services.AddInfrastructureServices();
//builder.Services.AddApplicationServices();
//builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddDbContext<AppDbContext>(opt =>
//{

//    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
//});


//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.MapControllers();
//app.Run();



using CodeWorldEducation.Application;
using CodeWorldEducation.Infrastructure;
using CodeWorldEducation.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DotNetEnv;

Env.TraversePath().Load();
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

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

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();