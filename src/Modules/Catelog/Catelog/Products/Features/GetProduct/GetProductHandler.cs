namespace Catelog.Products.Features.UpdateProduct;

public record GetProductsResult(List<ProductDto> Products);

public class GetProductsQueryHandler(CatelogDbContext context) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await context.Products
                                    .AsNoTracking()
                                    .ToListAsync(cancellationToken);

        var productsDto = products.Adapt<List<ProductDto>>();

        return new GetProductsResult(productsDto);
    }
}
