
namespace Basket.Basket.Features.AddItemIntoBasket;

public record AddItemToBasketRequest(string UserName, ShoppingCartItemDto ShoppingCartItem);

public record AddItemToBasketResponse(Guid Id);

public class AddItemToBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapPost("/basket/{userName}/items",
            async ([FromRoute] string userName,
                   [FromBody] AddItemToBasketRequest request, ISender sender) =>
        {
            var result = await sender.Send(new AddItemToBasketCommand(userName, request.ShoppingCartItem));

            var response = result.Adapt<AddItemToBasketResponse>();

            return Results.Created($"/basket/{response.Id}", response);
        }).Produces<AddItemToBasketResponse>(StatusCodes.Status201Created)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithSummary("Add Item To Basket")
          .WithDescription("Add Item To Basket");
    }
}
