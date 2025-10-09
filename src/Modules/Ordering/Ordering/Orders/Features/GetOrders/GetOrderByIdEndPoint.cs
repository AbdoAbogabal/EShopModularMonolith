namespace Ordering.Orders.Features.GetOrderById;

public record GetOrdersResponse(PaginatedResult<OrderDto> Orders);

public class GetOrdersEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Orders", async ([AsParameters] PaginatedRequest pagination, ISender sender) =>
        {
            var result = await sender.Send(new GetOrderQuery(pagination));

            var response = result.Adapt<GetOrdersResponse>();

            return Results.Ok(response);
        })
            .Produces<GetOrderByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithName("GetOrders")
            .WithSummary("GetOrders")
            .WithDescription("GetOrders");
    }
}
