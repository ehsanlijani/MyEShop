using MediatR;
using MyEShop.Domain.Entities.Products;

namespace MyEShop.Application.UseCases.Products.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<List<Product>>;



