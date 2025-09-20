namespace Catelog.Products.Features.UpdateProduct;

public record UpdateProductCommand
        (ProductDto Product)
        : ICommand<UpdateProductResult>;
