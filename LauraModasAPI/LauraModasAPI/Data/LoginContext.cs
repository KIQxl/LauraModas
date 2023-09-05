using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LauraModasAPI.Data
{
    public class LoginContext : IdentityDbContext<IdentityUser>
    {
        public LoginContext(DbContextOptions<LoginContext> opts) : base(opts)
        {
            
        }
    }
}
