namespace Catelog.Products.Features.UpdateProduct;

public record UpdateProductResult(bool IsSuccess);

public class UpdateProductCommandHandler(CatelogDbContext context,
                                         IValidator<UpdateProductCommand> validator,
                                         ILogger<UpdateProductCommandHandler> logger)
                                         : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var oldProduct = await context.Products
            .FindAsync([request.Product.Id], cancellationToken);

        if (oldProduct == null) throw new ProductNotFoundException(oldProduct.Id);

        UpdateProduct(request, oldProduct);

        context.Products.Update(oldProduct);

        await context.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }

    private static void UpdateProduct(UpdateProductCommand request, Product oldProduct)
    {
        oldProduct.Update(request.Product.Name,
                      request.Product.Categories,
                      request.Product.Description,
                      request.Product.Price,
                      request.Product.ImageFile);
    }
}
