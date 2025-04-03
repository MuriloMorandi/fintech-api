using Aplicacao.Core.Services;
using Microsoft.EntityFrameworkCore;
using Aplicacao.Dominio.Intefaces;
using Aplicacao.Infra.Context;
using Aplicacao.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Configurar autenticação JWT com Cognito
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_XXXXXXX"; // Substitua pelo seu User Pool ID
        options.Audience = "SEU_CLIENT_ID"; // Substitua pelo App Client ID do Cognito
    });

builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Adiciona os serviços necessários
builder.Services.AddHealthChecks();


// Registra a interface e a implementação do repositório genérico
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(); // Repositório
builder.Services.AddScoped<UsuariosService, UsuariosService>(); // Serviço

var app = builder.Build();

app.MapHealthChecks("/health"); // Health Check
app.MapControllers();

app.Run();