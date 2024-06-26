using FluentValidation;

namespace MyEShop.Application.UseCases.ProductCategory.Commands.Update;

public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
{
    public UpdateProductCategoryCommandValidator()
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

