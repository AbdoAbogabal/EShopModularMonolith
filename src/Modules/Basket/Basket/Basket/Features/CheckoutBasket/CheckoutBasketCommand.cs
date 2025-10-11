namespace Basket.Basket.Features.CheckoutBasket;

public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckout) : ICommand<CheckoutBasketResult>;
