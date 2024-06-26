using MediatR;
using MyEShop.Domain.IRepositories.Products;

namespace MyEShop.Application.UseCases.ProductCategory.Queries.GetAllProductCategories;

public class GetAllProductCategoryQueryHandler(IProductCategoryRepository productCategoryRepository) : IRequestHandler<GetAllProductCategoriesQuery, List<Domain.Entities.Products.ProductCategory>>
{
    public async Task<List<Domain.Entities.Products.ProductCategory>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
        => await productCategoryRepository.GetAllAsync(cancellationToken);

}

