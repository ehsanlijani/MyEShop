using Microsoft.EntityFrameworkCore;
using MyEShop.DataLayer.Context;
using MyEShop.DataLayer.Repositories.Common;
using MyEShop.Domain.Entities.Users;
using MyEShop.Domain.IRepositories.Users;

namespace MyEShop.DataLayer.Repositories.Users;

public class UserRepository(MyEShopDbContext dbContext) : GenericRepository<User>(dbContext), IUserRepository
{
    private readonly MyEShopDbContext _dbContext = dbContext;

    public async Task<bool> IsUserExistByEmailAsync(string email, CancellationToken cancellationToken)
         => await _dbContext.Users.AsNoTracking().AnyAsync(user => user.Email == email, cancellationToken).ConfigureAwait(false);

    public async Task<User> GetUserByEmail(string email, CancellationToken cancellationToken)
        => await _dbContext.Users.AsNoTracking().SingleOrDefaultAsync(user => user.Email == email, cancellationToken).ConfigureAwait(false);
}


