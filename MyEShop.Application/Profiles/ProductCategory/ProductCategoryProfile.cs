using AutoMapper;
using MyEShop.Application.UseCases.ProductCategory.Commands.Add;
using MyEShop.Application.UseCases.ProductCategory.Commands.Update;

namespace MyEShop.Application.Profiles.ProductCategory;

public class ProductCategoryProfile : Profile
{
    public ProductCategoryProfile()
    {
        CreateMap<AddProductCategoryCommand , Domain.Entities.Products.ProductCategory>().ReverseMap();
        CreateMap<UpdateProductCategoryCommand, Domain.Entities.Products.ProductCategory>().ReverseMap();
    }
}

