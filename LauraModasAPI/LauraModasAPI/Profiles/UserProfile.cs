using AutoMapper;
using LauraModasAPI.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace LauraModasAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, IdentityUser>();
        }
    }
}
