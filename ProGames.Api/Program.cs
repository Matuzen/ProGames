using Microsoft.EntityFrameworkCore;
using ProGames.Api.Context;
using ProGames.Api.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


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
var baseUrl = "https://localhost:7292";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });


var app = builder.Build();

// Middleware do Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/produtos/swagger.json", "API de Produtos");
    c.RoutePrefix = ""; // Exibe o Swagger na raiz do app (http://localhost:5000/)
});

app.UseCors(policy => policy.WithOrigins("https://localhost:7292", "https://localhost:7292").AllowAnyMethod().AllowAnyHeader().WithHeaders(HeaderNames.ContentType));

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
