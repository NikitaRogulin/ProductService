using ProductService.Products.Domain.Models;

namespace ProductService.Products.AppServices.ProductService
{
    public interface IProductService
    {
        public Task<long> Create(long id, string name, decimal price, CancellationToken cancellationToken = default);

        public Task<Product> GetById(long id, CancellationToken cancellationToken = default);

        public Task Update(long id, string name, decimal price, CancellationToken cancellationToken = default);
        public Task Delete(long id, CancellationToken cancellationToken = default);
    }
}