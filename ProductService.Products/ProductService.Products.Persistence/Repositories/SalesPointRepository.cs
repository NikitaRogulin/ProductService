using Microsoft.EntityFrameworkCore;
using ProductService.Products.Domain.Contracts.Models;
using ProductService.Products.Domain.IRepository;

namespace ProductService.Products.Persistence.Repositories;

public class SalesPointRepository : ISalesPointRepository
{
    private DbSet<SalesPoint> _dbSet;

    public SalesPointRepository(ProductsContext context)
    {
        _dbSet = context.SalePoints;
    }
    public void Create(SalesPoint salesPoint)
    {
        _dbSet.Add(salesPoint);
    }

    public ValueTask<SalesPoint?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return _dbSet.FindAsync(id, cancellationToken);
    }

    public void Update(SalesPoint salesPoint)
    {
        _dbSet.Attach(salesPoint);
        _dbSet.Entry(salesPoint).State = EntityState.Modified;
    }

    public void Delete(SalesPoint salesPoint)
    {
        _dbSet.Remove(salesPoint);
    }
}