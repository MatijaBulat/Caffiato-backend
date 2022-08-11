global using Caffiato.Models;
global using Microsoft.EntityFrameworkCore;
global using System.Text.Json.Serialization;
using Caffiato.Services.AddressService;
using Caffiato.Services.CaffeService;
using Caffiato.Services.DealService;
using Caffiato.Services.UserCaffeService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<CaffiatoDBContext>();
builder.Services.AddScoped<IUserCaffeService, UserCaffeService>();
builder.Services.AddScoped<ICaffeService, CaffeService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IDealService, DealService>();

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
