using System;
using Microsoft.EntityFrameworkCore;

using Apeideopera�ao.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Adiciona as interfaces e seus respectivos reposit�rios para inje��o de depend�ncia.
// Adicione os reposit�rios para todas as suas entidades (Usu�rios, Pedidos, etc.) aqui.
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
//builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
//builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
//builder.Services.AddScoped<IPedidosProdutosRepositorio, PedidosProdutosRepositorio>();
// FIM DAS INSTRU��ES

// IN�CIO DAS INSTRU��ES: Configure suas interfaces e a connection string aqui.
// 1. Configura a string de conex�o com o banco de dados.
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