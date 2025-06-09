namespace ProGames.Core.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string ImagemUrl { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public int CategoriaId { get; set; } // FK no banco de dados
    public Categoria? Categoria { get; set; } // Explicitando ainda mais o relacionamento com Categoria
    public ICollection<CarrinhoItem>? Itens { get; set; }

}
