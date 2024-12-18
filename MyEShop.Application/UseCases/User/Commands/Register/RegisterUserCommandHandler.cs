using AutoMapper;
using MediatR;
using MyEShop.Application.Wrappers;
using MyEShop.Domain.Contracts.Users;

namespace MyEShop.Application.UseCases.User.Commands.Register;

public class RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper) 
    : IRequestHandler<RegisterUserCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        bool isUserExistByEmail = await userRepository.IsUserExistByEmailAsync(request.Email , cancellationToken);

        if (isUserExistByEmail)
            return Result.Failure<bool>(ApplicationLayerCommonMessages.User.DuplicateEmail);

        Domain.Entities.Users.User user = mapper.Map<Domain.Entities.Users.User>(request);

        bool result = await userRepository.AddAsync(user, cancellationToken);

        if (!result)
            return Result.Failure<bool>(ApplicationLayerCommonMessages.Database.Failed);

        await userRepository.SaveChangesAsync(cancellationToken);

        return Result.Success(result);
    }
}

