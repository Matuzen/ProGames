namespace ProGames.Core.Models;
public class StatusVenda
{
    public int IdStatusVenda { get; set; }
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }

    // Propriedades de navegação
    public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
}
