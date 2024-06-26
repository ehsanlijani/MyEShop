using MediatR;
using MyEShop.Application.Wrappers;

#nullable disable

namespace MyEShop.Application.UseCases.Products.Commands.Delete;

public record DeleteProductCommand(long ProductId) : IRequest<Result<bool>>;



