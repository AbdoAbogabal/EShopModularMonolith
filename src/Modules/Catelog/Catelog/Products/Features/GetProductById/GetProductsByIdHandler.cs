namespace Catelog.Products.Features.GetProductById;

public record GetProductsByIdResult(ProductDto Product);

public class GetProductsByIdQueryHandler(CatelogDbContext context)
                                         : IQueryHandler<GetProductsByIdQuery, GetProductsByIdResult>
{
    public async Task<GetProductsByIdResult> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
    {
        var products = await context.Products
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(e => e.Id.Equals(request.Id), cancellationToken);

        var productDto = products.Adapt<ProductDto>();

        return new GetProductsByIdResult(productDto);
    }
}
