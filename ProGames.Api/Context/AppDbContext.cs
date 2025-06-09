using Microsoft.EntityFrameworkCore;
using ProGames.Core.Entities;
using System.Reflection;

namespace ProGames.Api.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Categoria>? Categorias { get; set;}
    public DbSet<Carrinho>? Carrinhos { get; set; }
    public DbSet<Usuario>? Usuarios { get; set; }
    public DbSet<CarrinhoItem>? CarrinhoItens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
