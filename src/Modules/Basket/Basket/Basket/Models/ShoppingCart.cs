namespace Basket.Basket.Models;

public class ShoppingCart : Aggregate<Guid>
{
    public string UserName { get; private set; } = default!;

    private readonly List<ShoppingCartItem> _items = new();
    public IReadOnlyList<ShoppingCartItem> Items => _items.AsReadOnly();
    public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity);


    public static ShoppingCart CreateNew(Guid id, string userName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(userName);

        var cart = new ShoppingCart
        {
            Id = id,
            UserName = userName
        };
        return cart;
    }

    public void AddItem(Guid productId, int quantity, string color, decimal price, string productName)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        var existingItem = _items.FirstOrDefault(item => item.ProductId == productId);
        if (existingItem != null)
            existingItem.Quantity += quantity;
        else
        {
            var newItem = new ShoppingCartItem(Guid.NewGuid(), productId, quantity, color, price, productName);
            _items.Add(newItem);
        }
    }

    public void RemoveItem(Guid productId)
    {
        var existingItem = _items.FirstOrDefault(item => item.ProductId == productId);
        if (existingItem != null)
            _items.Remove(existingItem);
    }
}
