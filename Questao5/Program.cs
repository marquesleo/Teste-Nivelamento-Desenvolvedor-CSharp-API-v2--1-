using MediatR;
using Questao5.Infrastructure.Sqlite;
using System.Reflection;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSingleton<Questao5.Infrastructure.Services.IMovimentacaoService, Questao5.Infrastructure.Services.MovimentacaoService>();
builder.Services.AddSingleton<Questao5.Infrastructure.Services.IContaCorrenteService, Questao5.Infrastructure.Services.ContaCorrenteService>();
builder.Services.AddSingleton<IContaCorrenteRepository, ContaCorrenteRepository>();
builder.Services.AddSingleton<IMovimentacaoRepository, MovimentacaoRepository>();


builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

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

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informa��es �teis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


