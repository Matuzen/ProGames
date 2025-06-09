namespace ProGames.Core.Models;
public class TipoVenda
{
    public int IdTipoVenda { get; set; }
    public string Nome { get; set; } = null!;

    // Propriedades de navegação
    public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
}
