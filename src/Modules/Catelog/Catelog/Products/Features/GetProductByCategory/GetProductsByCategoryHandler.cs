namespace Catelog.Products.Features.GetProductByCategory;

public record GetProductsByCategoryResult(List<ProductDto> Products);

public class GetProductsByCategoryQueryHandler(IProductRepository productRepository)
                                               : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductsByCategories(request.Category, cancellationToken);

        var productsDto = products.Adapt<List<ProductDto>>();

        return new GetProductsByCategoryResult(productsDto);
    }
}
