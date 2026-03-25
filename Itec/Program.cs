using InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using Application.Mapping;
using Domain.Interfaces.Services;
using Application.Services;
using Domain.Interfaces;
using Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationMapping();
builder.Services.AddDbContext<ItecDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<ITecnicoService, TecnicoService>();
builder.Services.AddScoped<ITecnicoRepository, TecnicoRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
