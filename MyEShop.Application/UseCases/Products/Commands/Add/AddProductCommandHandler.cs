using AutoMapper;
using MediatR;
using MyEShop.Application.Wrappers;
using MyEShop.Domain.Entities.Products;
using MyEShop.Domain.IRepositories.Products;

namespace MyEShop.Application.UseCases.Products.Commands.Add;

public class AddProductCommandHandler(IProductRepository productRepository , IMapper mapper) : IRequestHandler<AddProductCommand , Result<bool>>
{
    public async Task<Result<bool>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        Product product = mapper.Map<Product>(request);

        bool result = await productRepository.AddAsync(product , cancellationToken);

        if(result is false)
            return Result.Failure<bool>(ApplicationLayerCommonMessages.Database.Failed);

        await productRepository.SaveChangesAsync(cancellationToken);

        return Result.Success(result);
    }
}

