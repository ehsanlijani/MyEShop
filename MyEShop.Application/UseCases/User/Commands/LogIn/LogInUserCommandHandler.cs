using AutoMapper;
using MediatR;
using MyEShop.Application.Services.Interfaces;
using MyEShop.Application.Wrappers;
using MyEShop.Domain.IRepositories.Users;

namespace MyEShop.Application.UseCases.User.Commands.LogIn;

public class LogInUserCommandHandler(IUserRepository userRepository, ITokenService tokenService, IMapper mapper) : IRequestHandler<LogInUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LogInUserCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.User user = await userRepository.GetUserByEmail(request.Email, cancellationToken);

        if (user is null)
            return Result.Failure<string>(ApplicationLayerCommonMessages.User.UserNotFound);

        if (user.Password != request.Password)
            return Result.Failure<string>(ApplicationLayerCommonMessages.User.UserNotFound);

        string token = tokenService.CreateToken(user);

        return Result.Success(token);
    }
}

