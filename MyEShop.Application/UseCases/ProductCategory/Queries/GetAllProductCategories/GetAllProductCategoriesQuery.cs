using MediatR;

namespace MyEShop.Application.UseCases.ProductCategory.Queries.GetAllProductCategories;

public sealed record GetAllProductCategoriesQuery : IRequest<List<Domain.Entities.Products.ProductCategory>>;



