using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.AppServices;

public interface IProductsService
{
    public Task<Guid> Create(string name, decimal price, CancellationToken cancellationToken = default);

    public Task<Product> GetById(Guid id, CancellationToken cancellationToken = default);

    public Task Update(Guid id, string name, decimal price, CancellationToken cancellationToken = default);
    public Task Delete(Guid id, CancellationToken cancellationToken = default);
}