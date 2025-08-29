using System;
using Microsoft.EntityFrameworkCore;

using Apeideoperaçao.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Adiciona as interfaces e seus respectivos repositórios para injeção de dependência.
// Adicione os repositórios para todas as suas entidades (Usuários, Pedidos, etc.) aqui.
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
//builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
//builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
//builder.Services.AddScoped<IPedidosProdutosRepositorio, PedidosProdutosRepositorio>();
// FIM DAS INSTRUÇÕES

// INÍCIO DAS INSTRUÇÕES: Configure suas interfaces e a connection string aqui.
// 1. Configura a string de conexão com o banco de dados.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VendasContext>(options =>
    options.UseSqlServer(connectionString));

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