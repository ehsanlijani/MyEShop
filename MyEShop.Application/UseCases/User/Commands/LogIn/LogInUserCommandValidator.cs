using FluentValidation;

namespace MyEShop.Application.UseCases.User.Commands.LogIn;

public class LogInUserCommandValidator : AbstractValidator<LogInUserCommand>
{
    public LogInUserCommandValidator()
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
    }
}



