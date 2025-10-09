namespace Ordering.Orders.Features.CreateOrder;

public record CreateOrderRequest(OrderDto Order);
public record CreateOrderResponse(Guid OrderId);

public class CreateOrderEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Orders", async (CreateOrderRequest request, ISender sender) =>
        {
            var orderCommand = request.Adapt<CreateOrderCommand>();

            var result = await sender.Send(orderCommand);

            var response = result.Adapt<CreateOrderResponse>();

            return Results.Created($"/Orders/{response.OrderId}", response);
        })
            .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName("Create Order")
            .WithSummary("Create Order")
            .WithDescription("Create Order");
    }
}
