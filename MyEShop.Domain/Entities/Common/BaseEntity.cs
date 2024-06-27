namespace MyEShop.Domain.Entities.Common;

#nullable disable
public class BaseEntity<T>
{
    #region Properties

    public T Id { get; private set; }
    public bool IsDelete { get; private set; }
    public DateTime CreateDate { get; private set; } = DateTime.Now;

    #endregion
}

