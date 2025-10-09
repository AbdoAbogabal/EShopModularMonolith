namespace Ordering.Orders.Features.DeleteOrder;

public class DeleteCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteCommandValidator()
    {
        RuleFor(e => e.OrderId).NotEmpty().WithMessage("OrderId is required ");
    }
}
