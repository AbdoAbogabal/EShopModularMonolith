namespace Catelog.Products.Features.CreateProduct;

public record DeleteProductRequest(Guid ProductId);
public record DeleteProductResponse(bool IsSuccess);

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{productId}", async (Guid productId, ISender sender) =>
        {
            var result = await sender.Send(new DeleteProductCommand(productId));

            var response = result.Adapt<DeleteProductResponse>();

            return Results.Ok(response);
        }).WithName("DeleteProduct")
          .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .ProducesProblem(StatusCodes.Status404NotFound)
          .WithSummary("Delete Product")
          .WithDescription("Delete Product");

    }
}
