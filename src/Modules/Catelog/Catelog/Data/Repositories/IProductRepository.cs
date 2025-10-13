namespace Catelog.Data.Repositories;

public interface IProductRepository
{
    Task<Product> CreateProduct(CreateProductCommand command, CancellationToken cancellationToken);
    Task<bool> DeleteProduct(Guid id, CancellationToken cancellationToken);
    Task<int> GetCount(CancellationToken cancellationToken);
    Task<Product> GetProductById(Guid id, CancellationToken cancellationToken);
    Task<List<Product>> GetProducts(int pageSize, int pageNumber, CancellationToken cancellationToken);
    Task<List<Product>> GetProductsByCategories(string categories, CancellationToken cancellationToken);
    Task<bool> UpdateProduct(UpdateProductCommand request, CancellationToken cancellationToken);
}
