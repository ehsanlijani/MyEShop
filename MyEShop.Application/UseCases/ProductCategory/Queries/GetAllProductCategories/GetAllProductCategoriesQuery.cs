using MediatR;

namespace MyEShop.Application.UseCases.ProductCategory.Queries.GetAllProductCategories;

public record GetAllProductCategoriesQuery : IRequest<List<Domain.Entities.Products.ProductCategory>>;



