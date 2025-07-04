﻿namespace ProGames.Core.Models;
public class DescontoFormaPagamentoVenda
{
    public int Id { get; set; } // INT IDENTITY(1,1) (PK)
    public int IdFormaPagamento { get; set; } // INT NOT NULL (FK)
    public string? TipoDesconto { get; set; } // NVARCHAR(20)
    public decimal Valor { get; set; } // DECIMAL(10,2) NOT NULL
    public DateOnly DataInicio { get; set; } // DATE NOT NULL -> DateOnly
    public DateOnly DataFim { get; set; } // DATE NOT NULL -> DateOnly
    public bool Ativo { get; set; } = true; // BIT NOT NULL DEFAULT 1

    // Propriedade de navegação
    public FormaPagamento FormaPagamento { get; set; } = null!;
}
