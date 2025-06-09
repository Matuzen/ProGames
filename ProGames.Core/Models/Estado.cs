namespace ProGames.Core.Models;
public class Estado
{
    public int IdEstado { get; set; }
    public string Nome { get; set; } = null!; // NVARCHAR(100) NOT NULL
    public string Sigla { get; set; } = null!; // CHAR(2) NOT NULL UNIQUE

    // Propriedades de navegação
    public ICollection<Cidade> Cidades { get; set; } = new List<Cidade>();
}
