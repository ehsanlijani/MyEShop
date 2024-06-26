using MediatR;
using MyEShop.Application.Wrappers;

#nullable disable

namespace MyEShop.Application.UseCases.ProductCategory.Commands.Delete;

public record DeleteProductCategoryCommand(int ProductCategoryId) : IRequest<Result<bool>>
{
}

