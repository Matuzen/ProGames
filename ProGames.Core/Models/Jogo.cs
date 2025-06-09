namespace ProGames.Core.Models;
public class Jogo
{
    public int IdJogo { get; set; }
    public string Nome { get; set; } = null!; // NVARCHAR(150) NOT NULL

    // FKs para Desenvolvedora e Distribuidora (INT NOT NULL do ALTER TABLE)
    public int IdDesenvolvedora { get; set; }
    public int IdDistribuidora { get; set; }

    public DateOnly? DataLancamento { get; set; } // DATE (anulável)
    public int? IdGenero { get; set; } // INT (FK anulável)
    public string? Descricao { get; set; } // NVARCHAR(MAX)
    public decimal PrecoVenda { get; set; }
    public decimal PrecoLocacao { get; set; }

    public bool Ativo { get; set; } = true; // BIT NOT NULL DEFAULT 1 (do ALTER TABLE)

    // Propriedades de navegação
    public GeneroJogo? Genero { get; set; } // Pode ser nulo se IdGenero for nulo
    public Desenvolvedora Desenvolvedora { get; set; } = null!; // Não nula pois IdDesenvolvedora é NOT NULL
    public Distribuidora Distribuidora { get; set; } = null!; // Não nula pois IdDistribuidora é NOT NULL

    public ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
    public ICollection<MovimentacaoEstoque> MovimentacoesEstoque { get; set; } = new List<MovimentacaoEstoque>();
    public ICollection<Promocao> Promocoes { get; set; } = new List<Promocao>();
    public ICollection<VendaItem> VendaItens { get; set; } = new List<VendaItem>();
    public ICollection<CarrinhoDeVendas> ItensCarrinho { get; set; } = new List<CarrinhoDeVendas>();
    public ICollection<DescontoFormaPagamentoItem> DescontosFormaPagamentoItem { get; set; } = new List<DescontoFormaPagamentoItem>();

}
