using Microsoft.EntityFrameworkCore;
using ProductService.Products.Domain.Contracts.Models;
using ProductService.Products.Domain.IRepository;

namespace ProductService.Products.Persistence.Repositories;

public class SaleRepository : ISaleRepository
{
    private DbSet<Sale> _dbSet;

    public SaleRepository(ProductsContext context)
    {
        _dbSet = context.Sales;
    }
    public void Create(Sale sale)
    {
        _dbSet.Add(sale);
    }

    public ValueTask<Sale?> GetById(long id, CancellationToken cancellationToken = default)
    {
        return _dbSet.FindAsync(id, cancellationToken);
    }

    public void Update(Sale sale)
    {
        _dbSet.Attach(sale);
        _dbSet.Entry(sale).State = EntityState.Modified;
    }

    public void Delete(Sale sale)
    {
        _dbSet.Remove(sale);
    }
}