namespace Basket.Basket.Features.RemoveItemFromBasket;

public record RemoveItemFromBasketResponse(bool IsSuccess);

public class RemoveItemFromBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapDelete("/basket/{userName}/Items/{productId}",
               async ([FromRoute] string userName,
                      [FromRoute] Guid productId, ISender sender) =>
        {
            var result = await sender.Send(new RemoveItemFromBasketCommand(userName, productId));

            var response = result.Adapt<RemoveItemFromBasketResponse>();

            return Results.Ok(response);
        })
        .Produces<RemoveItemFromBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Remove Item From Basket")
        .WithDescription("Remove Item From Basket");

    }
}
