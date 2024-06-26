using MediatR;
using MyEShop.Application.Wrappers;

#nullable disable

namespace MyEShop.Application.UseCases.User.Commands.LogIn;

public record LogInUserCommand(string Email , string Password) : IRequest<Result<bool>>;



