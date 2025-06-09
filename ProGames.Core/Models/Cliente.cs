namespace ProGames.Core.Models;
public class Cliente
{
    public int IdCliente { get; set; }
    public string Nome { get; set; } = null!; // NVARCHAR(100) NOT NULL
    public string? SegundoNome { get; set; } // NVARCHAR(100)
    public string? Sobrenome { get; set; } // NVARCHAR(100)
    public string CPF_CNPJ { get; set; } = null!; // NVARCHAR(20) UNIQUE NOT NULL
    public DateOnly? DataNascimento { get; set; } // DATE (anulável)
    public bool Ativo { get; set; } = true; // BIT NOT NULL DEFAULT 1 (do ALTER TABLE)

    // Propriedades de navegação
    public ICollection<Contato> Contatos { get; set; } = new List<Contato>();
    public ICollection<EnderecoCliente> Enderecos { get; set; } = new List<EnderecoCliente>();
    public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
    public ICollection<CarrinhoDeVendas> ItensCarrinho { get; set; } = new List<CarrinhoDeVendas>();

}
