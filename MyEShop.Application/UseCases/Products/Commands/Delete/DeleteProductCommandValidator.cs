using FluentValidation;

namespace MyEShop.Application.UseCases.Products.Commands.Delete;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(p => p.ProductId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter valid ProductId"); ;
    }
}

