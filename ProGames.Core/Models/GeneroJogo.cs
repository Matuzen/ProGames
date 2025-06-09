namespace ProGames.Core.Models;
public class GeneroJogo
{
    public int IdGenero { get; set; }
    public string Nome { get; set; } = null!; // NVARCHAR(50) NOT NULL
    public string? Descricao { get; set; } // NVARCHAR(150)

    // Propriedades de navegação
    public ICollection<Jogo> Jogos { get; set; } = new List<Jogo>();
}
