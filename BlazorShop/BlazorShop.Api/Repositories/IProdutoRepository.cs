using BlazorShop.Api.Entities;

namespace BlazorShop.Api.Repositories;

public interface IProdutoRepository
{
    public Task<IEnumerable<Produto>> GetItens();
    public Task<Produto> GetItem(int id);
    public Task<IEnumerable<Produto>> GetItensByCategory(int id);
}
