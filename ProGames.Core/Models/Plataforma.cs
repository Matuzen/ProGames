namespace ProGames.Core.Models;
public class Plataforma
{
    public int IdPlataforma { get; set; }
    public string Nome { get; set; } = null!; // NVARCHAR(100) NOT NULL
    public int IdFabricante { get; set; } // INT NOT NULL (FK)
    public DateOnly? DataLancamento { get; set; } // DATE (anulável)

    // Propriedades de navegação
    public FabricantePlataforma Fabricante { get; set; } = null!;
    public ICollection<Promocao> Promocoes { get; set; } = new List<Promocao>();
    //public ICollection<CarrinhoDeVendas> ItensCarrinho { get; set; } = new List<CarrinhoDeVendas>();

}
