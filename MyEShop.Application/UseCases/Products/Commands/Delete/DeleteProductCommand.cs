using MediatR;
using MyEShop.Application.Wrappers;

#nullable disable

namespace MyEShop.Application.UseCases.Products.Commands.Delete;

public sealed record DeleteProductCommand(long ProductId) : IRequest<Result<bool>>;



