namespace Catelog.Products.Features.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Product).NotNull();

        RuleFor(x => x.Product.Price).GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.Product.Categories).NotEmpty().WithMessage("categories is required.");
        RuleFor(x => x.Product.ImageFile).NotEmpty().WithMessage("imageFile is required.");

        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("name is required.");
        RuleFor(x => x.Product.Name).MaximumLength(100).WithMessage("letters can't be more than 100");

        RuleFor(x => x.Product.Description).NotEmpty().WithMessage("description is required.");
        RuleFor(x => x.Product.Description).MaximumLength(500).WithMessage("letters can't be more than 500");
    }
}
