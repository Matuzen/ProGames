﻿using Microsoft.EntityFrameworkCore;
using ProGames.Api.Context;
using ProGames.Api.Repositories.Interfaces;
using ProGames.Core.DTOs;
using ProGames.Core.Entities;

namespace ProGames.Api.Repositories.Implementacoes;

public class CarrinhoCompraRepository : ICarrinhoCompraRepository
{
    private readonly AppDbContext _context;

    public CarrinhoCompraRepository(AppDbContext context)
    {
        _context =context;
    }

    public async Task<CarrinhoItem> AdicionarItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
    {
        if (await CarrinhoItemJaExiste(carrinhoItemAdicionaDto.CarrinhoId, carrinhoItemAdicionaDto.ProdutoId) == false)
        {
            // verifica se o produto existe e cria um novo item no carrinho
            var item = await (from produto in _context.Produtos
                              where produto.Id == carrinhoItemAdicionaDto.ProdutoId
                              select new CarrinhoItem
                              {
                                  CarrinhoId = carrinhoItemAdicionaDto.CarrinhoId,
                                  ProdutoId = produto.Id,
                                  Quantidade = carrinhoItemAdicionaDto.Quantidade
                              }).SingleOrDefaultAsync();

            // se o item existe então incluir o item no carrinho
            if(item is not null)
            {
                var resultado = await _context.CarrinhoItens.AddAsync(item);
                await _context.SaveChangesAsync();
                return resultado.Entity;
            }
        }
        return null;
    }

    private async Task<bool> CarrinhoItemJaExiste(int carrinhoId, int produtoId)
    {
        return await _context.CarrinhoItens.AnyAsync(c => c.CarrinhoId == carrinhoId && c.ProdutoId == produtoId);
    }

    public Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
    {
        throw new NotImplementedException();
    }

    public Task<CarrinhoItem> DeletaItem(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<CarrinhoItem> GetItem(int id)
    {
        return await (from carrinho in _context.Carrinhos
                      join carrinhoItem in _context.CarrinhoItens
                      on carrinho.Id equals carrinhoItem.CarrinhoId
                      where carrinhoItem.Id == id
                      select new CarrinhoItem
                      {
                          Id = carrinhoItem.Id,
                          ProdutoId = carrinhoItem.ProdutoId,
                          Quantidade = carrinhoItem.Quantidade,
                          CarrinhoId = carrinhoItem.CarrinhoId
                      }).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<CarrinhoItem>> GetItens(int usuarioId)
    {
        return await (from carrinho in _context.Carrinhos
                      join carrinhoItem in _context.CarrinhoItens
                      on carrinho.Id equals carrinhoItem.CarrinhoId
                      where carrinho.UsuarioId == usuarioId
                      select new CarrinhoItem
                      {
                          Id = carrinhoItem.Id,
                          ProdutoId = carrinhoItem.ProdutoId,
                          Quantidade = carrinhoItem.Quantidade,
                          CarrinhoId = carrinhoItem.CarrinhoId
                      }).ToListAsync();
    }
}
