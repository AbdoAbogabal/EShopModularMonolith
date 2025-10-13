namespace Catelog.Products.Features.DeleteProduct;

public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandHandler(IProductRepository productRepository)
                                        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var isSuccess = await productRepository.DeleteProduct(request.Id, cancellationToken);

        return new DeleteProductResult(isSuccess);
    }
}
