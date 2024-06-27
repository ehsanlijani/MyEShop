using MediatR;
using MyEShop.Application.Wrappers;

#nullable disable

namespace MyEShop.Application.UseCases.Products.Commands.Update;

public sealed record UpdateProductCommand(long ProductId, int ProductCategoryId, string Name, int Price, int Quantity, string ShortDescription, string Description) : IRequest<Result<bool>>;

