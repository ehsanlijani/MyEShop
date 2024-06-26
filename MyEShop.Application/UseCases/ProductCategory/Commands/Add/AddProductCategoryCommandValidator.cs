
using FluentValidation;

namespace MyEShop.Application.UseCases.ProductCategory.Commands.Add;

public class AddProductCategoryCommandValidator : AbstractValidator<AddProductCategoryCommand>
{
    public AddProductCategoryCommandValidator()
    {
        RuleFor(p => p.TitleInUrl)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Please enter valid TitleInUrl");

        RuleFor(p => p.Title)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Please enter valid Title");
    }

}

