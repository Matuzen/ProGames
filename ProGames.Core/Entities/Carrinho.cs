namespace ProGames.Core.Entities;

public class Carrinho
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public ICollection<CarrinhoItem>? Itens { get; set; }
}
