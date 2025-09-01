using Microsoft.EntityFrameworkCore;
using SeguroVeiculo.Infrastructure.Data;
using SeguroVeiculo.Domain.Interfaces;
using SeguroVeiculo.Infrastructure.Repositories;
using SeguroVeiculo.Infrastructure.Services;
using SeguroVeiculo.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Configurar EF Core para SQL Server local
builder.Services.AddDbContext<SeguroDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositórios
builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração para apontar para o JSON Server local
builder.Services.AddHttpClient<ISeguradoService, SeguradoService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:3001");
    client.Timeout = TimeSpan.FromSeconds(5);
});

// Injeção de dependência
builder.Services.AddScoped<CalcularSeguroUseCase>();
builder.Services.AddScoped<CriarSeguroUseCase>();
builder.Services.AddScoped<ObterSeguroUseCase>();
builder.Services.AddScoped<GerarRelatorioMediaModeloUseCase>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();