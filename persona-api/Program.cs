using System;
using Microsoft.EntityFrameworkCore;
using persona_api.Models.Entities;
using persona_api.Repositories;
using persona_api.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var envConn = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
var connectionString = !string.IsNullOrEmpty(envConn)
    ? envConn
    : builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PersonaDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IEstudioRepository, EstudioRepository>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<ITelefonoRepository, TelefonoRepository>();
builder.Services.AddScoped<IProfesionRepository, ProfesionRepository>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();