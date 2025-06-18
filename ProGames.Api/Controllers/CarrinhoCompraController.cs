using Microsoft.AspNetCore.Mvc;
using ProGames.Api.Mappings;
using ProGames.Api.Repositories.Interfaces;
using ProGames.Core.DTOs;

namespace ProGames.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarrinhoCompraController : ControllerBase
{
    private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;
    private readonly IProdutoRepository _produtoRepository;

    private ILogger<CarrinhoCompraController> logger;

    public CarrinhoCompraController(ICarrinhoCompraRepository
        carrinhoCompraRepository,
        IProdutoRepository produtoRepository,
        ILogger<CarrinhoCompraController> logger)
    {

        _carrinhoCompraRepository = carrinhoCompraRepository;
        _produtoRepository = produtoRepository;
        this.logger = logger;
    }

    [HttpGet]
    [Route("{usuarioId}/GetItens")]
    public async Task<ActionResult<IEnumerable<CarrinhoItemDto>>> GetItens(int usuarioId)
    {
        try
        {
            var carrinhoItens = await _carrinhoCompraRepository.GetItens(usuarioId);
            if(carrinhoItens == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            var produtos = await _produtoRepository.GetItens();
            if(produtos == null)
            {
                throw new Exception("Não existem produtos");
            }

            var carrinhoItensDto = carrinhoItens.ConverterCarrinhoItensParaDto(produtos);
            return Ok(carrinhoItensDto);

        }
        catch(Exception ex)
        {
            logger.LogError("# Erro ao obter itens do carrinho");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<CarrinhoItemDto>> GetItem(int id)
    {
        try
        {
            var carrinhoItem = await _carrinhoCompraRepository.GetItem(id);
            if(carrinhoItem == null)
            {
                return NotFound($"Item não encontrado"); // 404 status code
            }

            var produto = await _produtoRepository.GetItem(carrinhoItem.ProdutoId);

            if(produto == null)
            {
                return NotFound($"Item não existe na fonte de dados");
            }
            var cartItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);

            return Ok(cartItemDto);

        }
        catch(Exception ex)
        {
            logger.LogError($"## Erro ao obter o item = {id} do carrinho");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
