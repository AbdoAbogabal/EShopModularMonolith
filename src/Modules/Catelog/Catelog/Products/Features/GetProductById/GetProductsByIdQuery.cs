namespace Catelog.Products.Features.GetProductById;

public record GetProductsByIdQuery(Guid Id) : IQuery<GetProductsByIdResult>;
