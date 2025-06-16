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

    public async Task<ProdutoDto> GetItem(int id)
    {
        try
        {
            var response = await _httpCliente.GetAsync($"api/produtos/{id}");
            if (response.IsSuccessStatusCode) // Status Code 200-299
            { 
                if(response.StatusCode == System.Net.HttpStatusCode.NoContent) // status 204
                {
                    return default(ProdutoDto); // retorna os valores padrão/empty
                }
                return await response.Content.ReadFromJsonAsync<ProdutoDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Erro a obter produto pelo id = {id} - {message}");
                throw new Exception($"Status Code : {response.StatusCode} - {message}");
            }
        }
        catch (Exception)
        {
            _logger.LogError($"Erro a obter produto pelo id{id}");
            throw;
        }
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
