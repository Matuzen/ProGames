namespace ProGames.Core.Models;
public class Promocao
{
    public int IdPromocao { get; set; }
    public int IdJogo { get; set; } // INT NOT NULL (FK)
    public int IdPlataforma { get; set; } // INT NOT NULL (FK)
    public decimal PrecoPromocional { get; set; } // DECIMAL(10,2) NOT NULL
    public DateOnly DataInicio { get; set; } // DATE NOT NULL -> DateOnly
    public DateOnly DataFim { get; set; } // DATE NOT NULL -> DateOnly
    public bool Ativo { get; set; } = true; // BIT NOT NULL DEFAULT 1

    // Propriedades de navegação
    public Jogo Jogo { get; set; } = null!;
    public Plataforma Plataforma { get; set; } = null!;
}
