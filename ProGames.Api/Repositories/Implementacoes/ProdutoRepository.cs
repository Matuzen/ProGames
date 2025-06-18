using Microsoft.EntityFrameworkCore;
using ProGames.Api.Context;
using ProGames.Api.Repositories.Interfaces;
using ProGames.Core.Entities;

namespace ProGames.Api.Repositories.Implementacoes;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Produto> GetItem(int id)
    {
        var produto = await _context.Produtos.Include(c => c.Categoria).SingleOrDefaultAsync(c => c.Id == id);
        return produto;
    }

    public async Task<IEnumerable<Produto>> GetItens()
    {
        var produto = await _context.Produtos.Include(c => c.Categoria).ToListAsync();
        return produto;
    }

    public async Task<IEnumerable<Produto>> GetItensPorCategoria(int id)
    {
        var produto = await _context.Produtos.Include(c => c.Categoria).Where(c => c.Categoria.Id == id).ToListAsync();
        return produto;
    }
}
