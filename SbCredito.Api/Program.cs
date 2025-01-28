using FluentMigrator.Runner;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SbCredito.Aplicacao.Interfaces;
using SbCredito.Aplicacao.Repositorios;
using SbCredito.Aplicacao.Servicos;
using SbCredito.Aplicacao.Validadores;
using SbCredito.Infra;
using SbCredito.Infra.Migrations;
using SbCredito.Infra.Repositorios;
using System;
using Npgsql;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

builder.Services.AddDbContext<SbCreditoContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

using (var connection = new NpgsqlConnection(connectionString))
{
    connection.Open();
    Console.WriteLine("Conexão com banco de dados bem sucessedida");
}

builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(runner => runner
        .AddPostgres() // Usar o provedor PostgreSQL
        .WithGlobalConnectionString(connectionString) 
        .ScanIn(typeof(TituloMigration).Assembly).For.Migrations() 
    )
    .AddLogging(logging => logging.AddFluentMigratorConsole()); 


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<TituloValidador>();

builder.Services.AddScoped<ITituloService, TituloService>();
builder.Services.AddScoped<ITituloRepositorio, TituloRepositorio>();
builder.Services.AddScoped<IOperacaoService, OperacaoService>();
builder.Services.AddScoped<IOperacaoRepositorio, OperacaoRepositorio>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    migrator.MigrateUp(); // Executar todas as migrations pendentes
}

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
