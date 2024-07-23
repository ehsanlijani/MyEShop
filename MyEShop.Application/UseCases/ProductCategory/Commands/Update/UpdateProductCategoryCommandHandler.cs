using AutoMapper;
using MediatR;
using MyEShop.Application.Wrappers;
using MyEShop.Domain.Contracts.Products;

namespace MyEShop.Application.UseCases.ProductCategory.Commands.Update;

public class UpdateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository , IMapper mapper) :
    IRequestHandler<UpdateProductCategoryCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Products.ProductCategory productCategory =
            await productCategoryRepository.GetProductCategoryById(request.ProductCategoryId, cancellationToken);

        if (productCategory is null)
            return Result.Failure<bool>(ApplicationLayerCommonMessages.Database.NotFount);

        mapper.Map(request, productCategory);

        bool result = productCategoryRepository.Update(productCategory);

        if (!result)
            return Result.Failure<bool>(ApplicationLayerCommonMessages.Database.Failed);

        await productCategoryRepository.SaveChangesAsync(cancellationToken);
        return Result.Success(result);
    }
}

