namespace Catelog.Products.Features.CreateProduct;

public record CreateProductResult(Guid ProductId);

public class CreateProductCommandHandler(CatelogDbContext context,
                                         IValidator<CreateProductCommand> validator,
                                         ILogger<CreateProductCommandHandler> logger)
                                         : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = CreateProduct(request);

        await context.Products.AddAsync(product, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
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
