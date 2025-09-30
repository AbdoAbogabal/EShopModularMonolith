namespace Basket.Basket.Features.DeleteBasket;

public record DeleteBasketResult(bool Success);

public class DeleteBasketHandler(IBasketRepository basketRepository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(request.UserName);

        await basketRepository.DeleteBasket(request.UserName, cancellationToken);

        return new DeleteBasketResult(true);
    }
}
