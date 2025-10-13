namespace Catelog.Products.Features.GetProductById;


public class GetProductsByIdQueryHandler(IProductRepository productRepository)
                                         : IQueryHandler<GetProductsByIdQuery, GetProductsByIdResult>
{
    public async Task<GetProductsByIdResult> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductById(request.Id, cancellationToken);

        var productDto = product.Adapt<ProductDto>();

        return new GetProductsByIdResult(productDto);
    }
}
