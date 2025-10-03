
namespace Basket.Basket.Features.AddItemIntoBasket;

public record AddItemToBasketCommand(string UserName, ShoppingCartItemDto ShoppingCartItem)
            : ICommand<AddItemToBasketResult>;