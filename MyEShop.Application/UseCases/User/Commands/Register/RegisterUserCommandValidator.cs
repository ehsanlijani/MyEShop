using FluentValidation;

namespace MyEShop.Application.UseCases.User.Commands.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("pls enter valid email");

        RuleFor(p => p.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8)
            .WithMessage("Please enter valid password");

        RuleFor(p => p.ConfirmPassword)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8)
            .Matches(p => p.Password)
            .WithMessage("Please enter valid ConfirmPassword");
    }
}

