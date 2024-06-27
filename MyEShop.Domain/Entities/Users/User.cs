using MyEShop.Domain.Entities.Common;

#nullable disable

namespace MyEShop.Domain.Entities.Users;

public class User : BaseEntity<long>
{
    #region Properties

    public string Email { get; private set; }
    public string Password { get; private set; }

    #endregion
}

