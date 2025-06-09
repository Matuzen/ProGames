using Microsoft.EntityFrameworkCore;
using ProGames.Api.Context;
using ProGames.Api.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();

// Swagger configurado para exibir apenas o grupo "produtos"
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("produtos", new OpenApiInfo
    {
        Title = "API de Produtos",
        Version = "v1"
    });

    // Evita conflitos de nomes de classes
    c.CustomSchemaIds(type => type.FullName);
});


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Repositórios
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Middleware do Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/produtos/swagger.json", "API de Produtos");
    c.RoutePrefix = ""; // Exibe o Swagger na raiz do app (http://localhost:5000/)
});

app.UseHttpsRedirection();
app.UseAuthorization();

// Registra os endpoints dos controllers
app.MapControllers();

app.Run();
