using Microsoft.EntityFrameworkCore;
using ProductService.Products.Domain.Contracts.Models;
using ProductService.Products.Domain.IRepository;

namespace ProductService.Products.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private DbSet<Product> _dbSet;

    public ProductRepository(ProductsContext context)
    {
        _dbSet = context.Products;
    }
    
    public void Create(Product product)
    {
        _dbSet.Add(product);
    }

    public ValueTask<Product?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return _dbSet.FindAsync(id, cancellationToken);
    }

    public void Update(Product product)
    {
        _dbSet.Attach(product);
        _dbSet.Entry(product).State = EntityState.Modified;
    }

    public void Delete(Product product)
    {
        _dbSet.Remove(product);
    }
}