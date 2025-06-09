using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProGames.Core.Entities;

namespace ProGames.Api.Context.Mappings;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeUsuario).HasColumnType("NVARCHAR").HasMaxLength(100);

        builder.HasOne(u => u.Carrinho)
             .WithOne()
             .HasForeignKey<Carrinho>(c => c.UsuarioId);
    }
}
