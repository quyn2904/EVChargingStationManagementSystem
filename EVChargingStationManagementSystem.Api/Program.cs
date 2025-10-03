using EVChargingStationManagementSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;
using EVChargingStationManagementSystem.Api;
using EVChargingStationManagementSystem.Application.Mappings;
using EVChargingStationManagementSystem.Application.Interfaces;
using EVChargingStationManagementSystem.Infrastructure.Repositories;
using EVChargingStationManagementSystem.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IChargingStationRepository, ChargingStationRepository>();
builder.Services.AddScoped<ChargingStationService>();
// Add AutoMapper
builder.Services.AddAutoMapper(config => config.LicenseKey = builder.Configuration["AutoMapper:LicenseKey"], typeof(ChargingStationProfile)
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
