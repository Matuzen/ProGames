namespace ProGames.Core.Models;
public class EnderecoCliente
{
    public int IdEndereco { get; set; }
    public int IdCliente { get; set; } // INT NOT NULL (FK)
    public string Rua { get; set; } = null!; // NVARCHAR(100) NOT NULL
    public string Numero { get; set; } = null!; // NVARCHAR(20) NOT NULL
    public string? Complemento { get; set; } // NVARCHAR(100)
    public string Bairro { get; set; } = null!; // NVARCHAR(50) NOT NULL
    public string Cep { get; set; } = null!; // NVARCHAR(9) NOT NULL

    public int? IdCidade { get; set; } // INT (FK para Cidade, adicionado por ALTER TABLE, assume como nullable aqui)

    // Propriedades de navegação
    public Cliente Cliente { get; set; } = null!;
    public Cidade? Cidade { get; set; } // Propriedade de navegação para a FK IdCidade (pode ser nulo se IdCidade for nulo)

}
