namespace ProGames.Core.Models;
public class Cidade
{
    public int IdCidade { get; set; }
    public string Nome { get; set; } = null!; // NVARCHAR(100) NOT NULL
    public string CepInicio { get; set; } = null!; // NVARCHAR(9) NOT NULL
    public string CepFim { get; set; } = null!; // NVARCHAR(9) NOT NULL
    public string Ddd { get; set; } = null!; // CHAR(2) NOT NULL

    public int IdEstado { get; set; } // INT NOT NULL (do ALTER TABLE)
    public Estado Estado { get; set; } = null!; // Propriedade de navegação para a FK IdEstado

    // Propriedades de navegação
    public ICollection<EnderecoCliente> EnderecosCliente { get; set; } = new List<EnderecoCliente>();

}
