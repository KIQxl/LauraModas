using LauraModasAPI.Services.Iservices;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LauraModasAPI.Services
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;

        public TokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(IdentityUser user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("Username", user.UserName),
                new Claim("Id", user.Id),
                new Claim("Email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AzBy192837MnS7r0g0nNoFFFnui39yvd0u3nmc"));

            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    expires: DateTime.Now.AddHours(5),
                    claims: claims,
                    signingCredentials: signinCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
