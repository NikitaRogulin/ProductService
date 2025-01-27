using Microsoft.EntityFrameworkCore;
using ProductService.Products.Domain.IRepository;
using ProductService.Products.Domain.Models;

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

    public async ValueTask<SalesPoint?> GetById(long id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Include(x => x.ProvidedProducts)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
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