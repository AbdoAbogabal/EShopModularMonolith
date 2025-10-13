namespace Catelog.Products.Features.GetProduct;

public record GetProductsResult(PaginatedResult<ProductDto> Products);

public class GetProductsQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var pageSize = request.PaginatedRequest.PageSize;
        var pageNumber = request.PaginatedRequest.PageNumber;

        var count = await productRepository.GetCount(cancellationToken);

        var products = await productRepository.GetProducts(pageSize, pageNumber, cancellationToken);

        var productsDto = products.Adapt<List<ProductDto>>();

        return new GetProductsResult(
                   new PaginatedResult<ProductDto>(
                      pageNumber,
                      pageSize,
                      count,
                      productsDto));
    }
}
