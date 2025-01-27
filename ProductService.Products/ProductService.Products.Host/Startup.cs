using ProductService.Products.AppServices;
using ProductService.Products.Domain;
using ProductService.Products.Domain.Models;
using ProductService.Products.Persistence;

namespace ProductService.Products.Host;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAppServices();
        services.AddPersistence();
    }

    public void Configure(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            SeedData(unitOfWork);
        }

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseRouting();
        app.UseEndpoints(builder => builder.MapControllers());
    }

    private void SeedData(IUnitOfWork unitOfWork)
    {
        unitOfWork.ProductRepository.Create(new Product(1, "Молоко", 88));
        unitOfWork.ProductRepository.Create(new Product(2, "Мясо", 440));
        unitOfWork.ProductRepository.Create(new Product(3, "Икра", 5000));
        unitOfWork.ProductRepository.Create(new Product(4, "Хлеб", 65));

        unitOfWork.SalesPointRepository.Create(new SalesPoint()
        {
            Id = 1,
            Name = "Lenta",
        });
        unitOfWork.CommitAsync(CancellationToken.None);
    }
}