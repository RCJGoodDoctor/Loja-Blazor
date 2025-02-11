using BlazorShop.Api.Entities;
using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlazorShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetItens()
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
                var produtosDto = produtos.ConverterProdutosParaDto();
                return Ok(produtosDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,"Erro a acessar a base de dados");
        }
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProdutoDTO>> GetItem(int id)
    {
        try
        {
            var produto = await _produtoRepository.GetItem(id);
            if (produto is null)
            {
                return NotFound();
            }
            else
            {
                var produtoDto = produto.ConverterProdutoParaDto();
                return Ok(produtoDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro a acessar a base de dados");
        }
    }
    [HttpGet]
    [Route("GetItensByCategory/{categoryId}")]
    public async Task<ActionResult<ProdutoDTO>> GetItensByCategory(int categoryId)
    {
        try
        {
            var produtos = await _produtoRepository.GetItensByCategory(categoryId);
            if (produtos is null)
            {
                return NotFound();
            }
            else
            {
                var produtoDto = produtos.ConverterProdutosParaDto();
                return Ok(produtoDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro a acessar a base de dados");
        }
    }

}
