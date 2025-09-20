namespace Catelog.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Product> Products => new List<Product>()
    {
        Product.Create(Guid.NewGuid(), "IPhone 16",["Slim"], "Description for Product 1", 10.0m,"imageFile1"),
        Product.Create(Guid.NewGuid(), "Samsung A55",["Flat"], "Description for Product 2", 15.0m,"imageFile2"),
        Product.Create(Guid.NewGuid(), "Samsung S24",["Fold"], "Description for Product 3", 15.0m,"imageFile3"),
        Product.Create(Guid.NewGuid(), "Huawuie",["Huge"], "Description for Product 4", 15.0m,"imageFile4"),
    };
}
