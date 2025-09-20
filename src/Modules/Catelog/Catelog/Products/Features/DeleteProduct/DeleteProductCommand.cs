namespace Catelog.Products.Features.UpdateProduct;

public record DeleteProductCommand
        (Guid Id)
        : ICommand<DeleteProductResult>;
