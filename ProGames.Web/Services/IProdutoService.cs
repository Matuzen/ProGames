using ProGames.Core.DTOs;

namespace ProGames.Web.Services;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDto>> GetItens();
}
