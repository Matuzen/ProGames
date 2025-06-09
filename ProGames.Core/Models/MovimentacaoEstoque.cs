namespace ProGames.Core.Models;
public class MovimentacaoEstoque
{
    public int IdMovimentacao { get; set; }
    public int IdJogo { get; set; } // INT NOT NULL (FK)
    public int QuantidadeMovimentada { get; set; } // INT NOT NULL
    public string TipoMovimentacao { get; set; } = null!; // NVARCHAR(50) NOT NULL
    public DateTime DataMovimentacao { get; set; } // DATETIME NOT NULL DEFAULT GETDATE() -> DateTime
    public int IdUsuario { get; set; } // INT NOT NULL (FK)

    // Propriedades de navegação
    public Jogo Jogo { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}
