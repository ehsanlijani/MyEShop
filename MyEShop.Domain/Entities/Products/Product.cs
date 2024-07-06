using MyEShop.Domain.Entities.Common;

#nullable disable

namespace MyEShop.Domain.Entities.Products;

public class Product : BaseEntity<long>
{
    #region Properties

    public string Name { get; private set; }

    public int Price { get; private set; }

    public int Quantity { get; private set; }

    public string ShortDescription { get; private set; }

    public string Description { get; private set; }

    #endregion

    #region Relations
    public int ProductCategoryId { get; private set; }

    public ProductCategory ProductCategory { get; set; }

    #endregion
}

