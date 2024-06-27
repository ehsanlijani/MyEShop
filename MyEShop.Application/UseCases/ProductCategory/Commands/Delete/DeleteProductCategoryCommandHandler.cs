using MediatR;
using MyEShop.Application.Wrappers;
using MyEShop.Domain.IRepositories.Products;

namespace MyEShop.Application.UseCases.ProductCategory.Commands.Delete;

public class DeleteProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository) : IRequestHandler<DeleteProductCategoryCommand , Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Products.ProductCategory productCategory =
            await productCategoryRepository.GetProductCategoryById(request.ProductCategoryId, cancellationToken);

        if (productCategory == null)
            return Result.Failure<bool>(ApplicationLayerCommonMessages.Database.NotFount);

        bool result = productCategoryRepository.Delete(productCategory);

        if (!result)
            return Result.Failure<bool>(ApplicationLayerCommonMessages.Database.Failed);

        await productCategoryRepository.SaveChangesAsync(cancellationToken);
        return Result.Success(result);
    }
}

