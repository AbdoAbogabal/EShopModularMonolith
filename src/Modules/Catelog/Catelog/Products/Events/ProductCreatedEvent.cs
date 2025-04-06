namespace Catelog.Products.Events;

public record ProductCreatedEvent(Product product) : IDomainEvent;
