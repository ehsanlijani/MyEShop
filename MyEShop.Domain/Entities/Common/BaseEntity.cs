using MyEShop.Domain.Contracts.Common;

namespace MyEShop.Domain.Entities.Common;

#nullable disable
public class BaseEntity<T> : IDeletableEntity, IAuditableEntity
{
    #region Properties

    public T Id { get; private set; }
    public long? DeletedByUserId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted
    {
        get
        {
            if (DeletedAt is not null || DeletedAt != DateTime.MinValue)
                return true;

            else
                return false;
        }
    }
    public long? CreatedByUserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public long? ModifiedByUserId { get; set; }
    public DateTime? ModifiedAt { get; set; }

    #endregion

}

