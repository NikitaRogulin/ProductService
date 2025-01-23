using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.AppServices;

public class ProductService : IProductsService
{
    public async Task<Guid> Create(string name, decimal price, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Update(Guid id, string name, decimal price, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}