namespace ProGames.Core.Models;
public class Usuario
{
    public int IdUsuario { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public bool Ativo { get; set; } = true; // Adicionado do ALTER TABLE

    // Propriedades de navegação (se houver)
    public ICollection<MovimentacaoEstoque> MovimentacoesEstoque { get; set; } = new List<MovimentacaoEstoque>();
    public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
    public ICollection<CarrinhoDeVendas> ItensCarrinho { get; set; } = new List<CarrinhoDeVendas>();
}
