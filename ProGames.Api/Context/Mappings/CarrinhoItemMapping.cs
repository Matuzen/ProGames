using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProGames.Core.Entities;

namespace ProGames.Api.Context.Mappings;

public class CarrinhoItemMapping : IEntityTypeConfiguration<CarrinhoItem>
{
    public void Configure(EntityTypeBuilder<CarrinhoItem> builder)
    {
        builder.ToTable("CarrinhoItem");
        builder.HasKey(x => x.Id);

        builder.Property(x=>x.Id).UseIdentityColumn();

        builder.Property(x => x.CarrinhoId).HasColumnType("INT");
        builder.Property(x => x.ProdutoId).HasColumnType("INT");
        builder.Property(x => x.Quantidade).HasColumnType("INT");

        builder.HasOne(x => x.Produto)
        .WithMany(p => p.Itens)  // <-- indicar a propriedade inversa na entidade Produto
        .HasForeignKey(x => x.ProdutoId);

    }
}
