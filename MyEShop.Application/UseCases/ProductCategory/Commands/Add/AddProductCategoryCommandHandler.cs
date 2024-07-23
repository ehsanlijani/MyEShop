using AutoMapper;
using MediatR;
using MyEShop.Application.Wrappers;
using MyEShop.Domain.Contracts.Products;

namespace MyEShop.Application.UseCases.ProductCategory.Commands.Add;

public class AddProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository , IMapper mapper)
    : IRequestHandler<AddProductCategoryCommand, Result<bool>>
{

    public async Task<Result<bool>> Handle(AddProductCategoryCommand request, CancellationToken cancellationToken)
    {
        bool isExist = await productCategoryRepository.IsProductCategoryExistsByNameInUrl(request.TitleInUrl , cancellationToken);

        if (isExist)
            return Result.Failure<bool>(ApplicationLayerCommonMessages.Database.DuplicateTitle);

        Domain.Entities.Products.ProductCategory productCategory = mapper.Map<Domain.Entities.Products.ProductCategory>(request);

        bool result = await productCategoryRepository.AddAsync(productCategory, cancellationToken);

        if (result is false) 
            return Result.Failure<bool>(ApplicationLayerCommonMessages.Database.Failed);

        await productCategoryRepository.SaveChangesAsync(cancellationToken);

        return Result.Success(result);
    }
}

