using MyEShop.Domain.Entities.Common;

#nullable disable

namespace MyEShop.Domain.Entities.Products;

public class Product : BaseEntity<long>
{
    #region Properties

    public int ProductCategoryId { get; set; }

    public string Name { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public string ShortDescription { get; set; }

    public string Description { get; set; }

    #endregion

    #region Relations

    public ProductCategory ProductCategory { get; set; }

    #endregion
}

