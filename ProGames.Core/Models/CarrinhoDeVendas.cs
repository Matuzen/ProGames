namespace ProGames.Core.Models;
public class CarrinhoDeVendas
{
    public int IdCarrinho { get; set; }
    public int IdFinalizarVenda { get; set; } // INT IDENTITY(1,1) (PK)
    public int? IdCliente { get; set; } // INT (FK anulável)
    public int IdJogo { get; set; } // INT NOT NULL (FK)
    public int IdPlataforma { get; set; } // INT NOT NULL (FK)
    public decimal PrecoOriginal { get; set; } // DECIMAL(10,2) NOT NULL
    public decimal? PrecoComDesconto { get; set; } // DECIMAL(10,2) (anulável)
    public int Quantidade { get; set; } // INT NOT NULL DEFAULT 1
    public DateTime DataAdicionado { get; set; } // DATETIME NOT NULL DEFAULT GETDATE() -> DateTime
    public int IdUsuario { get; set; } // INT NOT NULL (FK)

    // Propriedades de navegação
    public Cliente? Cliente { get; set; } // Pode ser nulo se IdCliente for nulo
    public Jogo Jogo { get; set; } = null!;
    public Plataforma Plataforma { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}
