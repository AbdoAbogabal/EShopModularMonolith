using Catelog.Products.Events;

namespace Catelog.Products.Models;

public class Product : Aggregate<Guid>
{
    public string Name { get; private set; } = default!;
    public string ImageFile { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    public decimal Price { get; private set; }

    public List<string> Categories { get; private set; } = new();

    public static Product Create(Guid id, string name, List<string> categories, string description, decimal price, string imageFile)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new Product()
        {
            Id = id,
            Name = name,
            Price = price,
            ImageFile = imageFile,
            Categories = categories,
            Description = description,
        };

        product.AddDomainEvent(new ProductCreatedEvent(product));

        return product;
    }

    public void Update(string name, List<string> categories, string description, decimal price, string imageFile)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        Name = name;
        ImageFile = imageFile;
        Categories = categories;
        Description = description;

        if (Price != price)
        {
            Price = price;
            AddDomainEvent(new ProductPriceChangedEvent(this));
        }
    }
}
