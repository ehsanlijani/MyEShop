#nullable disable

using MediatR;
using MyEShop.Application.Wrappers;

namespace MyEShop.Application.UseCases.ProductCategory.Commands.Add;

public record AddProductCategoryCommand(string Title, string TitleInUrl) : IRequest<Result<bool>>;



