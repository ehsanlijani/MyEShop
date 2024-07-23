using MediatR;
using MyEShop.Domain.Contracts.Products;
using MyEShop.Domain.Entities.Products;

namespace MyEShop.Application.UseCases.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
         => await productRepository.GetAllAsync(cancellationToken);

}

