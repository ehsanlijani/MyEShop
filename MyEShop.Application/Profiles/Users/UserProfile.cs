using AutoMapper;
using MyEShop.Application.UseCases.User.Commands.Register;
using MyEShop.Domain.Entities.Users;

namespace MyEShop.Application.Profiles.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserCommand, User>().ReverseMap();
    }
}



