namespace Catelog.Products.Features.GetProduct;

public record GetProductsResult(PaginatedResult<ProductDto> Products);

public class GetProductsQueryHandler(CatelogDbContext context) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var pageNumber = request.PaginatedRequest.PageNumber;
        var pageSize = request.PaginatedRequest.PageSize;

        var count = await context.Products.CountAsync();

        var products = await context.Products
                                    .AsNoTracking()
                                    .Skip((pageNumber) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync(cancellationToken);

        var productsDto = products.Adapt<List<ProductDto>>();

        return new GetProductsResult(
            new PaginatedResult<ProductDto>(
           pageNumber,
           pageSize,
           count,
           productsDto));
    }
}
