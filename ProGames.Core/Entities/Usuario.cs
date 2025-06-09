namespace ProGames.Core.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string NomeUsuario { get; set; } = string.Empty;
    public Carrinho? Carrinho { get; set; } // relacionamento 1:1
}
