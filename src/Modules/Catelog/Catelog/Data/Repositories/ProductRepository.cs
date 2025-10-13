namespace Catelog.Data.Repositories;

public class ProductRepository(CatelogDbContext context)
             : IProductRepository
{
    public async Task<Product> CreateProduct(CreateProductCommand command, CancellationToken cancellationToken)
    {
        Product product = CreateProduct(command);

        await context.Products.AddAsync(product, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return product;
    }

    public async Task<Product> GetProductById(Guid id, CancellationToken cancellationToken)
    {
        var product = await context.Products
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken)
                                  ?? throw new ProductNotFoundException(id);

        return product;
    }

    public async Task<List<Product>> GetProductsByCategories(string categories, CancellationToken cancellationToken)
    {
        var products = await context.Products
                                    .AsNoTracking()
                                    .Where(e => e.Categories.Contains(categories))
                                    .ToListAsync(cancellationToken);

        return products;
    }

    public async Task<List<Product>> GetProducts(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var products = await context.Products
                                    .AsNoTracking()
                                    .Skip((pageNumber) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync(cancellationToken);

        return products;
    }

    public async Task<int> GetCount(CancellationToken cancellationToken) =>
           await context.Products.CountAsync(cancellationToken);

    public async Task<bool> DeleteProduct(Guid id, CancellationToken cancellationToken)
    {
        var product = await context.Products
          .FindAsync([id], cancellationToken) ?? throw new ProductNotFoundException(id);

        context.Products.Remove(product);

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> UpdateProduct(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var oldProduct = await context.Products
            .FindAsync([request.Product.Id], cancellationToken);

        if (oldProduct == null) throw new ProductNotFoundException(oldProduct.Id);

        UpdateProduct(request, oldProduct);

        context.Products.Update(oldProduct);

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private static void UpdateProduct(UpdateProductCommand request, Product oldProduct)
    {
        oldProduct.Update(request.Product.Name,
                          request.Product.Categories,
                          request.Product.Description,
                          request.Product.Price,
                          request.Product.ImageFile);
    }

    private static Product CreateProduct(CreateProductCommand request)
    {
        return Product.Create(Guid.NewGuid(),
                              request.Product.Name,
                              request.Product.Categories,
                              request.Product.Description,
                              request.Product.Price,
                              request.Product.ImageFile);
    }
}
