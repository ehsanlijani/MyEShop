using MyEShop.Domain.Entities.Users;
using MyEShop.Domain.IRepositories.Common;

namespace MyEShop.Domain.IRepositories.Users;

public interface IUserRepository : IGenericRepository<User>
{
    Task<bool> IsUserExistByEmailAsync(string email, CancellationToken cancellationToken);

    Task<User> GetUserByEmail(string email, CancellationToken cancellationToken);
}

