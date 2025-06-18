using ProGames.Core.DTOs;
using ProGames.Core.Entities;

namespace ProGames.Api.Repositories.Interfaces;

public interface ICarrinhoCompraRepository
{
    Task<CarrinhoItem> AdicionarItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
    Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);
    Task<CarrinhoItem> DeletaItem(int id);
    Task<CarrinhoItem> GetItem(int id);
    Task<IEnumerable<CarrinhoItem>> GetItens(int usuarioId);
}
