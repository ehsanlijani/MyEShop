using MediatR;
using MyEShop.Application.Wrappers;

#nullable disable

namespace MyEShop.Application.UseCases.ProductCategory.Commands.Update;

public sealed record UpdateProductCategoryCommand(long ProductCategoryId , string Title, string TitleInUrl) : IRequest<Result<bool>>;



