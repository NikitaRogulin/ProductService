using Microsoft.Extensions.DependencyInjection;
using ProductService.Products.Domain;
using ProductService.Products.Domain.IRepository;
using ProductService.Products.Persistence.Repositories;

namespace ProductService.Products.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<ISalesPointRepository, SalesPointRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<ProductsContext>();
        
        return services;
    }
}