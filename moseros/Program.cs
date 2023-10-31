using Microsoft.EntityFrameworkCore;
using moseros.Models;
using moseros.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IMoseros, MoserosService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Conexion Base de Datos

builder.Services.AddDbContext<MoserosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("AppSettings").GetSection("DefaultConnection").Value);

});

var appSettingsSection = builder.Configuration.GetSection("AppSettings");

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
