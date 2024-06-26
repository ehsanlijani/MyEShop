using MyEShop.Domain.Entities.Users;

namespace MyEShop.Application.Services.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}

