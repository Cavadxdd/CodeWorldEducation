using CodeWorldEducation.Persistence.Contexts;
using CodeWorldEducation.Persistence.ServiceRegistration;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddDbContext<AppDbContext>(opt =>
{
  
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();