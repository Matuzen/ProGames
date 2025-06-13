using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ProGames.Web;
using ProGames.Web.Services; // <- Importante para IProdutoService e ProdutoService

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// URL da sua API
var baseUrl = "https://localhost:7292"; // Certifique-se de que esta é a porta da sua API

// Registro do HttpClient + ProdutoService
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

await builder.Build().RunAsync();
