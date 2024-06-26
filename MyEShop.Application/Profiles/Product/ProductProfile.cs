using AutoMapper;
using MyEShop.Application.UseCases.Products.Commands.Add;
using MyEShop.Application.UseCases.Products.Commands.Update;

namespace MyEShop.Application.Profiles.Product;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<AddProductCommand , Domain.Entities.Products.Product>().ReverseMap();
        CreateMap<UpdateProductCommand, Domain.Entities.Products.Product>().ReverseMap();
    }
}

