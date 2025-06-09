namespace ProGames.Core.Models; 
public class Contato
{
    public int IdContato { get; set; }
    public int IdCliente { get; set; } // INT NOT NULL (FK)
    public string? Telefone { get; set; } // NVARCHAR(20)
    public string? Email { get; set; } // NVARCHAR(100)

    // Propriedade de navegação (lado "Um")
    public Cliente Cliente { get; set; } = null!;
}
