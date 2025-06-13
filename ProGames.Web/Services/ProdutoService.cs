using ProGames.Core.DTOs;
using System.Net.Http.Json;

namespace ProGames.Web.Services;

public class ProdutoService : IProdutoService
{
    // Faz chamadas HTTP para APIs
    public HttpClient _httpCliente;

    // Registra mensagens no log (informações/erros)
    public ILogger<ProdutoService> _logger;
    
    public ProdutoService(HttpClient httpClient, ILogger<ProdutoService> logger)
    {
        _httpCliente = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<ProdutoDto>> GetItens()
    {
        try
        {
            var produtosDto = await _httpCliente.GetFromJsonAsync<IEnumerable<ProdutoDto>>("api/produtos");
            return produtosDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao acessar produtos : api/produtos");
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}
