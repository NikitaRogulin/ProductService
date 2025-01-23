namespace ProductService.Products.Api.Contracts;

public static class WebRoutes
{
    public const string BasePath = "api";
    
    public static class Product
    {
        public const string Path = BasePath + "/product";
        public const string GetById =  "/{id}";
        public const string Create = "/create";
        public const string Delete = GetById + "/delete";
        public const string Update = "/update";
    }
}