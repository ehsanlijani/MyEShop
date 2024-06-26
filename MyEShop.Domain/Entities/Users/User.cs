using MyEShop.Domain.Entities.Common;

#nullable disable

namespace MyEShop.Domain.Entities.Users;

public class User : BaseEntity<long>
{
    #region Properties

    public string Email { get; set; }
    public string Password { get; set; }

    #endregion
}

