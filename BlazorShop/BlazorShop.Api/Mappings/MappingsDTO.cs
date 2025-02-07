using BlazorShop.Api.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Api.Mappings;

public static class MappingsDTO
{
    public static IEnumerable<CategoriaDTO> ConverterCategoriaParaDto(this IEnumerable<Categoria> categorias)
    {
        return categorias.Select(categoria => new CategoriaDTO()
        {
            Id = categoria.Id,
            Nome = categoria.Nome,
            IconCSS = categoria.IconCSS
        }).ToList();
    }
    public static IEnumerable<ProdutoDTO> ConverterProdutoParaDto(this IEnumerable<Produto> produtos)
    {
        return produtos.Select(produto => new ProdutoDTO()
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            ImagemUrl = produto.ImagemUrl,
            Preco = produto.Preco,
            Quantidade = produto.Quantidade,
            CategoriaId = produto.Categoria.Id,
            CategoriaNome = produto.Categoria.Nome
        }).ToList();
    }
    public static IEnumerable<CarrinhoItemDTO> ConverterCarrinhosItensParaDTO(this IEnumerable<CarrinhoItem> carrinhos, IEnumerable<Produto> produtos)
    {
        return carrinhos.Join(
            produtos,
            carrinho => carrinho.ProdutoId,
            produto => produto.Id,
            (carrinho, produto) => new CarrinhoItemDTO
                {
                    Id = carrinho.Id,
                    ProdutoId = carrinho.ProdutoId,
                    ProdutoNome = produto.Nome,
                    Quantidade = carrinho.Quantidade,
                    Preco = produto.Preco,
                    ProdutoDescricao = produto.Descricao,
                    ProdutoImagemURL = produto.ImagemUrl,
                    CarrinhoId = carrinho.CarrinhoId,
                    PrecoTotal = produto.Preco * carrinho.Quantidade
                }
            ).ToList();

    }
    public static CarrinhoItemDTO ConverterCarrinhoItemParaDto(this CarrinhoItem carrinho, Produto produto)
    {
        return new CarrinhoItemDTO
        {
            Id = carrinho.Id,
            ProdutoId = carrinho.ProdutoId,
            ProdutoNome = produto.Nome,
            Quantidade = carrinho.Quantidade,
            Preco = produto.Preco,
            ProdutoDescricao = produto.Descricao,
            ProdutoImagemURL = produto.ImagemUrl,
            CarrinhoId = carrinho.CarrinhoId,
            PrecoTotal = produto.Preco * carrinho.Quantidade
        };
    }
}
