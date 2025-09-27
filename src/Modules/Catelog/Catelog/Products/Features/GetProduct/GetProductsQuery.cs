namespace Catelog.Products.Features.GetProduct;

public record GetProductsQuery(PaginatedRequest PaginatedRequest) : IQuery<GetProductsResult>;
