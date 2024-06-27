using Microsoft.EntityFrameworkCore;
using MyEShop.DataLayer.Context;
using MyEShop.DataLayer.Repositories.Common;
using MyEShop.Domain.Entities.Users;
using MyEShop.Domain.IRepositories.Users;

namespace MyEShop.DataLayer.Repositories.Users;

public class UserRepository(MyEShopDbContext dbContext) : GenericRepository<User>(dbContext), IUserRepository
{
    private readonly MyEShopDbContext _dbContext = dbContext;

    public async Task<bool> IsUserExistByEmailAsync(string email)
         => await _dbContext.Users.AnyAsync(user => user.Email == email);

    public async Task<User> GetUserByEmail(string email)
        => await _dbContext.Users.SingleOrDefaultAsync(user => user.Email == email);
}


