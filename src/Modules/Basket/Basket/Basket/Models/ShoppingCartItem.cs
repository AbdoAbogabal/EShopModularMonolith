namespace Basket.Basket.Models;

public class ShoppingCartItem : Entity<Guid>
{
    public string Color { get; private set; } = default!;
    public int Quantity { get; internal set; } = default!;

    public Guid ProductId { get; private set; } = default!;
    public Guid ShoppingCartId { get; private set; } = default!;

    public decimal Price { get; private set; } = default!;
    public string ProductName { get; private set; } = default!;

    //[HINT] made internal so that only the ShoppingCart Class can create instances of this class
    internal ShoppingCartItem(Guid shoppingCartId, Guid productId, int quantity, string color, decimal price, string productName)
    {
        Color = color;
        Price = price;
        Quantity = quantity;
        ProductId = productId;
        ProductName = productName;
        ShoppingCartId = shoppingCartId;
    }
}
