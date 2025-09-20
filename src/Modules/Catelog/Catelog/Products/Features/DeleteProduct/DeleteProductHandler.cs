namespace Catelog.Products.Features.UpdateProduct;

public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandHandler(CatelogDbContext context) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {

        var product = await context.Products
            .FindAsync([request.Id], cancellationToken);

        if (product == null) throw new Exception($"Product not found: {product.Id}");

        context.Products.Remove(product);

        await context.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }

}
