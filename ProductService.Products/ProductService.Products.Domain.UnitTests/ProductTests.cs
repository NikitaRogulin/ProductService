using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Domain.UnitTests;
using Xunit;

public class ProductTests
{
    private readonly long Id = 1;
    private string Name = "Молоко";
    private decimal Price = 74;

    [Fact]
    public void Create_valid_model_using_with_correct_prop()
    {
        var product = new Product(Id, Name, Price);
        
        Assert.Equal(Id, product.Id);
        Assert.Equal(Name, product.Name);
        Assert.Equal(Price, product.Price);
    }
    [Fact]
    public void Create_negaitve_parameters_throws_E()
    {
        string Name = "";
        decimal Price = -74;

        Assert.Throws<Exception>(() =>
            new Product(Id, Name, Price));
    }
}