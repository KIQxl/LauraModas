using LauraModasAPI.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace LauraModasAPI.Services.Iservices
{
    public interface IUserServices
    {
        public Task<IdentityResult> CreateUser(CreateUserDto request);
        public Task<string> LogUser(LoginUserDto request);
        public Task<IdentityUser> GetUser(LoginUserDto request);
    }
}
