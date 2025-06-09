namespace ProGames.Core.Models;
public class VendaItem
{
    public int IdVendaItem { get; set; }
    public int IdVenda { get; set; } // INT NOT NULL (FK)
    public int IdJogo { get; set; } // INT NOT NULL (FK)
    public decimal PrecoVenda { get; set; } // DECIMAL(10,2) NOT NULL
    public int Quantidade { get; set; } // INT NOT NULL

    // Propriedades de navegação
    public Venda Venda { get; set; } = null!;
    public Jogo Jogo { get; set; } = null!;
}
