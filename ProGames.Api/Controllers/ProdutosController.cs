using Microsoft.AspNetCore.Mvc;
using ProGames.Api.Mappings;
using ProGames.Api.Repositories;
using ProGames.Core.DTOs;

namespace ProGames.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    // referencia a classe e dá uma instância da classe concreta
    private readonly IProdutoRepository _produtoRepository;


    public ProdutosController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItems() 
    {
        try
        {
            var produtos = await _produtoRepository.GetItens();
            if(produtos is null)
            {
                return NotFound();
            }
            else
            {
                var produtosDtos = produtos.ConverterProdutosParaDto();
                return Ok(produtosDtos);
            }
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
        }

    }



    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProdutoDto>> GetItem(int id)
    {
        try
        {
            var produto = await _produtoRepository.GetItem(id);
            if (produto is null)
            {
                return NotFound("Produto não localizado");
            }
            else
            {
                var produtoDto = produto.ConverterProdutoParaDto();
                return Ok(produtoDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
        }

    }

    [HttpGet]
    [Route("GetItensPorCategoria/{categoriaId}")]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItensPorCategoria(int categoriaId)
    {
        try
        {
            var produtos = await _produtoRepository.GetItensPorCategoria(categoriaId);
            var produtosDto = produtos.ConverterProdutosParaDto();
            return Ok(produtosDto);
            
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
        }
    }
}
