using MyEShop.Domain.Entities.Common;

#nullable disable

namespace MyEShop.Domain.Entities.Products;

public class ProductCategory : BaseEntity<int>
{
    #region Properties

    public string Title { get; set; }
    public string TitleInUrl { get; set; }

    #endregion

    #region Relations

    public ICollection<Product> products { get; set; }

    #endregion

}


