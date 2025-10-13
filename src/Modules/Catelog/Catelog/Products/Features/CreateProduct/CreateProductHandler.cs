namespace Catelog.Products.Features.CreateProduct;

public record CreateProductResult(Guid ProductId);

public class CreateProductCommandHandler(IProductRepository productRepository)
                                        : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await productRepository.CreateProduct(request, cancellationToken);

        return new CreateProductResult(product.Id);
    }
}
