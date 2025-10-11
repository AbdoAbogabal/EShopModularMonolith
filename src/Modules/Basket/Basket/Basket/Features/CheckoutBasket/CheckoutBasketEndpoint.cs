namespace Basket.Basket.Features.CheckoutBasket;

public record CheckoutBasketResponse(bool IsSuccess);
public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckout);

public class CheckoutBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<CheckoutBasketCommand>();

            var result = await sender.Send(command);

            var resposne = result.Adapt<CheckoutBasketResponse>();

            return Results.Ok(resposne);
        }).WithName("Checkout Basket")
          .WithSummary("Checkout Basket")
          .Produces<CheckoutBasketResponse>(StatusCodes.Status201Created)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithDescription("Checkout Basket")
          .RequireAuthorization();

    }
}
