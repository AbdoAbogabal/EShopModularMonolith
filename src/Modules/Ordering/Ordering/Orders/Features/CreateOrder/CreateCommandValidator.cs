using FluentValidation;

namespace Ordering.Orders.Features.CreateOrder;

public class CreateCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(e => e.Order.OrderName).NotEmpty().WithMessage("OrderName is required ");
    }
}
