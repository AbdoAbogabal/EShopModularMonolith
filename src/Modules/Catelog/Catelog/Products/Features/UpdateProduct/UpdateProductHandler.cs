namespace Catelog.Products.Features.UpdateProduct;

public record UpdateProductResult(bool IsSuccess);

public class UpdateProductCommandHandler(IProductRepository productRepository)
                                         : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var isSuccess = await productRepository.UpdateProduct(request, cancellationToken);

        return new UpdateProductResult(isSuccess);
    }
}