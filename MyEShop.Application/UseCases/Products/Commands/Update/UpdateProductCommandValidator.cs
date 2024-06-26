using FluentValidation;

namespace MyEShop.Application.UseCases.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(255)
            .WithMessage("Please enter valid Name");

        RuleFor(p => p.ShortDescription)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(300)
            .WithMessage("Please enter valid ShortDescription");

        RuleFor(p => p.Description)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(3000)
            .WithMessage("Please enter valid Description");

        RuleFor(p => p.Price)
            .NotNull()
            .NotEmpty()
            .WithMessage("Please enter valid Price");

        RuleFor(p => p.Quantity)
            .NotNull()
            .NotEmpty()
            .WithMessage("Please enter valid Quantity");

        RuleFor(p => p.ProductCategoryId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Please enter valid ProductCategoryId");
    }
}

