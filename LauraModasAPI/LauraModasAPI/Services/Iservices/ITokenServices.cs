using Microsoft.AspNetCore.Identity;

namespace LauraModasAPI.Services.Iservices
{
    public interface ITokenServices
    {
        public string GenerateToken(IdentityUser user);
    }
}
