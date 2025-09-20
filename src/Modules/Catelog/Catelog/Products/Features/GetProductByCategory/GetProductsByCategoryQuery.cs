namespace Catelog.Products.Features.UpdateProduct;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;
