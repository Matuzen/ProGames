namespace ProGames.Core.Models;
public class Venda
{
    public int IdVenda { get; set; }
    public int IdCliente { get; set; } // INT NOT NULL (FK)
    public DateTime DataVenda { get; set; } // DATETIME2 NOT NULL DEFAULT GETDATE() -> DateTime
    public int IdTipoVenda { get; set; } // INT NOT NULL (FK)
    public DateTime? DataDevolucao { get; set; } // DATETIME2 (anulável)
    public decimal? ValorTotal { get; set; } // DECIMAL(10,2) (anulável)
    public decimal? Desconto { get; set; } // DECIMAL(10,2) (anulável)
    public int IdFormaPagamento { get; set; } // INT NOT NULL (FK)
    public int IdStatusVenda { get; set; } // INT NOT NULL (FK)
    public int IdUsuario { get; set; } // INT NOT NULL (FK)

    // Propriedades de navegação
    public Cliente Cliente { get; set; } = null!;
    public TipoVenda TipoVenda { get; set; } = null!;
    public FormaPagamento FormaPagamento { get; set; } = null!;
    public StatusVenda StatusVenda { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;

    public ICollection<VendaItem> ItensVenda { get; set; } = new List<VendaItem>();
}
