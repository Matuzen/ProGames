namespace ProGames.Core.Models;
public class FabricantePlataforma
{
    public int IdFabricante { get; set; }
    public string Nome { get; set; } = null!;

    // Propriedades de navegação
    public ICollection<Plataforma> Plataformas { get; set; } = new List<Plataforma>();
}
