namespace ProductService.Products.Api.Contracts;

public static class WebRoutes
{
    public const string BasePath = "api";
    
    public static class Product
    {
        public const string Path = BasePath + "/product";
        public const string GetById = Path + "/{id}";
        public const string Create = Path + "/create";
        public const string Delete =  GetById + "/delete";
        public const string Update = Path + "/update";
    }
    public static class Sale
    {
        public const string Path = BasePath + "/sale";
        public const string GetById = Path + "/{id}";
        public const string Create = Path + "/create";
        public const string Delete = GetById + "/delete";
        public const string Update = Path + "/update";
    }
    public static class SalesPoint
    {
        public const string Path = BasePath + "/salesPoint";
        public const string GetById = Path + "/{id}";
        public const string Create = Path + "/create";
        public const string Delete = GetById + "/delete";
        public const string Update = Path + "/update";
    }
}