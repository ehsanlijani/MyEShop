namespace MyEShop.Domain.Entities.Common;

#nullable disable
public class BaseEntity<T>
{
    #region Properties

    public T Id { get; set; }
    public bool IsDelete { get; set; }
    public DateTime CreateDate { get; set; }

    #endregion
}

