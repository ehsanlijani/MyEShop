using MyEShop.Domain.Contracts.Common;
using MyEShop.Domain.Entities.Users;

namespace MyEShop.Domain.Contracts.Users;

public interface IUserRepository : IGenericRepository<User>
{
    Task<bool> IsUserExistByEmailAsync(string email, CancellationToken cancellationToken);

    Task<User> GetUserByEmail(string email, CancellationToken cancellationToken);
}

