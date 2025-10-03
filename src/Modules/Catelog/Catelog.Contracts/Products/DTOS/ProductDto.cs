namespace Catelog.Contracts.Products.DTOS;

public record ProductDto(Guid Id, string Name, List<string> Categories, string Description, string ImageFile, decimal Price);
