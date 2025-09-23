namespace Catelog.Products.Features.GetProductByCategory;

public record GetProductsByCategoryResult(List<ProductDto> Products);

public class GetProductsByCategoryQueryHandler(CatelogDbContext context)
                                               : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await context.Products
                                    .AsNoTracking()
                                    .Where(e => e.Categories.Contains(request.Category))
                                    .ToListAsync(cancellationToken);

        var productsDto = products.Adapt<List<ProductDto>>();

        return new GetProductsByCategoryResult(productsDto);
    }
}
