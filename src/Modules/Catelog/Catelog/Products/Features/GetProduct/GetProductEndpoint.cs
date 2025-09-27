namespace Catelog.Products.Features.GetProduct;

public record GetProductRequest();
public record GetProductResponse(PaginatedResult<ProductDto> Products);

public class GetProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] PaginatedRequest paginatedRequest, ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery(paginatedRequest));

            var response = result.Adapt<GetProductsResult>();

            return Results.Ok(response);
        }).WithName("GetProducts")
          .Produces<GetProductResponse>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithSummary("Get Products")
          .WithDescription("Get Products");

    }
}
