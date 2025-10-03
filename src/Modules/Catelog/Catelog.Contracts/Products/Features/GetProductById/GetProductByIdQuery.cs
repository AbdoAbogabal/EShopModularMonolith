namespace Catelog.Contracts.Products.Features.GetProductById;

public record GetProductsByIdResult(ProductDto Product);

public record GetProductsByIdQuery(Guid Id) : IQuery<GetProductsByIdResult>;
