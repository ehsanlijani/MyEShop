namespace MyEShop.Domain.Contracts.Common;

public interface IDeletableEntity : IEntity
{
    public long? DeletedByUserId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; }
}