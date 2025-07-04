﻿using System.Collections.ObjectModel;

namespace ProGames.Core.Entities;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string IconCSS { get; set; } = string.Empty;
    public Collection<Produto>? Produtos { get; set; }
}
