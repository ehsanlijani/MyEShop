using MediatR;
using MyEShop.Application.Wrappers;

#nullable disable

namespace MyEShop.Application.UseCases.User.Commands.Register;

public record RegisterUserCommand(string Email , string Password , string ConfirmPassword) : IRequest<Result<bool>>;



