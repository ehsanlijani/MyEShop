using AutoMapper;
using MediatR;
using MyEShop.Application.Wrappers;
using MyEShop.Domain.Entities.Products;
using MyEShop.Domain.IRepositories.Products;
using MyShop.Application;

namespace MyEShop.Application.UseCases.Products.Commands.Update;

public class UpdateProductCommandHandler(IProductRepository productRepository , IMapper mapper) : IRequestHandler<UpdateProductCommand , Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await productRepository.GetProductByIdAsync(request.ProductId , cancellationToken);

        if (product is null)
            return Result.Failure<bool>(CommonMessages.Database.NotFount);
        mapper.Map(request, product);


        bool result = productRepository.Update(product);

        if (!result)
            return Result.Failure<bool>(CommonMessages.Database.Failed);

        await productRepository.SaveChangesAsync(cancellationToken);
        return Result.Success(result);
    }
}

