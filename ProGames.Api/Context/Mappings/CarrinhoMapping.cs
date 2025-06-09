using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProGames.Core.Entities;

namespace ProGames.Api.Context.Mappings;

public class CarrinhoMapping : IEntityTypeConfiguration<Carrinho>
{
    public void Configure(EntityTypeBuilder<Carrinho> builder)
    {
        builder.ToTable("Carrinho");
        builder.HasKey(x => x.Id);

        builder.Property(x=>x.UsuarioId).HasColumnType("INT");

        builder.HasMany(c => c.Itens)
               .WithOne(c => c.Carrinho)
               .HasForeignKey(c => c.CarrinhoId);
    }
}
