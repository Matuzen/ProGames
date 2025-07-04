﻿namespace ProGames.Core.Models;
public class Desenvolvedora
{
    public int IdDesenvolvedora { get; set; }
    public string Nome { get; set; } = null!; // VARCHAR(100) UNIQUE NOT NULL

    // Propriedades de navegação
    public ICollection<Jogo> Jogos { get; set; } = new List<Jogo>();
}
