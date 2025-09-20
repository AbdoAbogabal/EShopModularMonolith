namespace Catelog.Products.Features.UpdateProduct;

public record GetProductsByIdQuery(Guid Id) : IQuery<GetProductsByIdResult>;
