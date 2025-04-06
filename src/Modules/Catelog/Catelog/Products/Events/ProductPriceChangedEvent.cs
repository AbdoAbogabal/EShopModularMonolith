namespace Catelog.Products.Events;

public record ProductPriceChangedEvent(Product product) : IDomainEvent;
