using MediatR;
using MyEShop.Application.Wrappers;
using MyEShop.Domain.Contracts.Products;

namespace MyEShop.Application.UseCases.Products.Commands.Delete;

public class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand , Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Products.Product product =
            await productRepository.GetProductByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
            return Result.Failure<bool>(ApplicationLayerCommonMessages.Database.NotFount);

        bool result = productRepository.Delete(product);

        if (!result)
            return Result.Failure<bool>(ApplicationLayerCommonMessages.Database.Failed);

        await productRepository.SaveChangesAsync(cancellationToken);
        return Result.Success(result);
    }
}

