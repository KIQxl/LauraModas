using AutoMapper;
using LauraModasAPI.Dtos.UserDtos;
using LauraModasAPI.Services.Iservices;
using Microsoft.AspNetCore.Identity;

namespace LauraModasAPI.Services
{
    public class UserServices : IUserServices
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;
        public readonly ITokenServices _tokenServices;
        public readonly IMapper _mapper;
        public UserServices(UserManager<IdentityUser> manager, IMapper mapper, SignInManager<IdentityUser> signInManager, ITokenServices tokenServices)
        {
            this._userManager = manager;
            this._mapper = mapper;
            this._signInManager = signInManager;
            this._tokenServices = tokenServices;

        }

        public async Task<IdentityUser> GetUser(LoginUserDto request)
        {
            IdentityUser user = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName.Equals(request.Username.ToUpper()));

            return user;
        }

        public async Task<IdentityResult> CreateUser(CreateUserDto request)
        {

            try
            {
                IdentityUser user = _mapper.Map<IdentityUser>(request);

                IdentityResult result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    throw new Exception("Falha ao criar usuário");
                }

                return result;
            } catch (Exception ex)
            {
                throw new Exception($"Falha ao criar usuário: {request.ToString()}");
            }
            
        }

        public async Task<string> LogUser(LoginUserDto request)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

                if (!result.Succeeded)
                {
                    new ApplicationException("Usuário não autenticado");
                }

                IdentityUser user = await GetUser(request);

                var token = _tokenServices.GenerateToken(user);

                return token;


            } catch(Exception ex)
            {
                throw new Exception($"Falha ao autenticar {ex.Message}");
            }

        }

    }
}
