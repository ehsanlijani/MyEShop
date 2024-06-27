using MyEShop.Domain.Entities.Common;

#nullable disable

namespace MyEShop.Domain.Entities.Products;

public class ProductCategory : BaseEntity<int>
{
    #region Properties

    public string Title { get; private set; }
    public string TitleInUrl { get; private set; }

    #endregion

    #region Relations

    public ICollection<Product> products { get; set; }

    #endregion

}


