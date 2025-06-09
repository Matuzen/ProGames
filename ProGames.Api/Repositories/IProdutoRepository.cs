using ProGames.Core.Entities;

namespace ProGames.Api.Repositories;

public interface IProdutoRepository
{
    // obter todos os itens de um carrinho
    Task<IEnumerable<Produto>> GetItens();

    // obter um item específico pelo Id
    Task<Produto> GetItem(int id);

    // retornar todos os produtos de uma categoria
    Task<IEnumerable<Produto>> GetItensPorCategoria(int id);
}
