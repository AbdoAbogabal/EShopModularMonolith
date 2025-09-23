namespace Catelog.Products.Features.DeleteProduct;

public record DeleteProductCommand
        (Guid Id)
        : ICommand<DeleteProductResult>;
