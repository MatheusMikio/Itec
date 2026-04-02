using InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using Application.Mapping;
using Domain.Interfaces.Services;
using Application.Services;
using Domain.Interfaces;
using Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationMapping();
builder.Services.AddDbContext<ItecDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// JWT Configuration
var secretKey = builder.Configuration.GetSection("AppSettings")["SecretKey"];
var key = Encoding.ASCII.GetBytes(secretKey!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

// Authorization Policies
builder.Services.AddAuthorization(options =>
{
    // Policy para Técnicos ou Admin
    options.AddPolicy("TecnicoOrAdmin", policy =>
        policy.RequireRole("Tecnico", "Admin"));

    // Policy para Clientes ou Admin
    options.AddPolicy("ClienteOrAdmin", policy =>
        policy.RequireRole("Cliente", "Admin"));

    // Policy apenas para Admin
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<ITecnicoService, TecnicoService>();
builder.Services.AddScoped<ITecnicoRepository, TecnicoRepository>();

builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();
builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();

builder.Services.AddScoped<IFaturaService, FaturaService>();
builder.Services.AddScoped<IFaturaRepository, FaturaRepository>();

builder.Services.AddScoped<IServicoService, ServicoService>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
