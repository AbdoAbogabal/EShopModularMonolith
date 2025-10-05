namespace Catelog.Products.Events;

public record ProductPriceChangedEvent(Product Product) : IDomainEvent;
