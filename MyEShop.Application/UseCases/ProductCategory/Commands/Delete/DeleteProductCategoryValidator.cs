using FluentValidation;

namespace MyEShop.Application.UseCases.ProductCategory.Commands.Delete;

public class DeleteProductCategoryValidator : AbstractValidator<DeleteProductCategoryCommand>
{
    public DeleteProductCategoryValidator()
    {
        RuleFor(p => p.ProductCategoryId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter valid ProductCategoryId");
    }
}

