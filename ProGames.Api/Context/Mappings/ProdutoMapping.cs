using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProGames.Core.Entities;

namespace ProGames.Api.Context.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");
        builder.HasKey(x=>x.Id);

        builder.Property(x => x.Nome)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(80)
              .IsRequired();     


        builder.Property(x => x.Descricao).HasColumnType("NVARCHAR").HasMaxLength(255);

        builder.Property(x => x.ImagemUrl).HasColumnType("NVARCHAR").HasMaxLength(255);

        builder.Property(x => x.Preco).HasColumnType("DECIMAL(10,2)").IsRequired(true);

        builder.Property(x=>x.Quantidade).HasColumnType("INT").IsRequired(true);

        builder.Property(x => x.CategoriaId).HasColumnType("INT");

        builder.HasOne(p => p.Categoria) // Produto tem uma Categoria
               .WithMany(p=>p.Produtos)             // Categoria pode ter muitos Produtos (sem propriedade de navegação reversa em Categoria?)
               .HasForeignKey(p => p.CategoriaId);
    }
}
