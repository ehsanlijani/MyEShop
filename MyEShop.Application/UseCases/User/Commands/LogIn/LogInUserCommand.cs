using MediatR;
using MyEShop.Application.Wrappers;

#nullable disable

namespace MyEShop.Application.UseCases.User.Commands.Login; 

public record LoginUserCommand(string Email , string Password) : IRequest<Result<string>>;



