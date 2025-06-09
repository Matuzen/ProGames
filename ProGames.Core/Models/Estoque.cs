namespace ProGames.Core.Models;
public class Estoque
{
    public int IdEstoque { get; set; }
    public int IdJogo { get; set; } // INT NOT NULL (FK)
    public int Quantidade { get; set; } // INT NOT NULL

    // Propriedade de navegação
    public Jogo Jogo { get; set; } = null!;
}
