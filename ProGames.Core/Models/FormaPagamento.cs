namespace ProGames.Core.Models;
public class FormaPagamento
{
    public int IdFormaPagamento { get; set; }
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }

    // Propriedades de navegação
    public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
    public ICollection<DescontoFormaPagamentoVenda> DescontosVenda { get; set; } = new List<DescontoFormaPagamentoVenda>();
    public ICollection<DescontoFormaPagamentoItem> DescontosItem { get; set; } = new List<DescontoFormaPagamentoItem>();
}
