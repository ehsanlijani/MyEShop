using MediatR;
using MyEShop.Application.Wrappers;

#nullable disable

namespace MyEShop.Application.UseCases.Products.Commands.Add;

public record AddProductCommand(int ProductCategoryId, string Name, int Price, int Quantity, string ShortDescription, string Description) : IRequest<Result<bool>>;




