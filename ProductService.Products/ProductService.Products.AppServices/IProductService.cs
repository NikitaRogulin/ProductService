using System.Collections;
using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.AppServices;

public interface IProductService
{
    public Task<long> Create(long id, string name, decimal price, CancellationToken cancellationToken = default);

    public Task<Product> GetById(long id, CancellationToken cancellationToken = default);

    public Task Update(long id, string name, decimal price, CancellationToken cancellationToken = default);
    public Task Delete(long id, CancellationToken cancellationToken = default);
}