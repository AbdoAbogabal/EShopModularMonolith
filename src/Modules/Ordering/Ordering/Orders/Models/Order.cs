namespace Ordering.Orders.Models;

public class Order : Aggregate<Guid>
{
    private readonly List<OrderItem> _items = new();
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

    public Guid CustomerId { get; private set; } = default!;
    
    public string OrderName { get; private set; } = default!;

    public Payment Payment { get; private set; } = default!;
    public Address ShippingAddress { get; private set; } = default!;
    public Address BillingAddress { get; private set; } = default!;

    public decimal TotalPrice => _items.Sum(e => e.Price * e.Quantity);

    public static Order Create(Guid id, Guid customerId, string orderName, Address shippingAddress, Address billingAddress, Payment payment)
    {
        var order = new Order()
        {
            Id = id,
            Payment = payment,
            OrderName = orderName,
            CustomerId = customerId,
            BillingAddress = billingAddress,
            ShippingAddress = shippingAddress,
        };

        order.AddDomainEvent(new OrderCreatedEvent(order));

        return order;
    }

    public void AddProduct(Guid productId, int quantity, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        var existingItem = Items.FirstOrDefault(e => e.ProductId == productId);
        if (existingItem is not null)
            existingItem.Quantity += quantity;
        else
        {
            var orderItem = new OrderItem(Id, productId, quantity, price);
            _items.Add(orderItem);
        }
    }

    public void RemoveProduct(Guid productId)
    {
        var item = Items.FirstOrDefault(e => e.ProductId == productId);
        if (item is not null)
            _items.Remove(item);
    }
}
