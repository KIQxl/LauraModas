using LauraModasAPI.Dtos.UserDtos;
using LauraModasAPI.Services.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LauraModasAPI.Controllers
{
    [ApiController]
    [Route("v1/LauraModas/user")]
    public class UserController : ControllerBase
    {

        public readonly IUserServices _userServices;
        

        public UserController(IUserServices userServices)
        {
            this._userServices = userServices;
        }

        [HttpPost]
        [Route("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto request)
        {
            IdentityResult result = await _userServices.CreateUser(request);

            return Ok("Usuário Cadastrado");

        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDto request)
        {
            try
            {
                var token = await _userServices.LogUser(request);
                IdentityUser user = await _userServices.GetUser(request);

                return Ok(new
                {
                    user,
                    token
                });
            } catch (Exception ex)
            {
                return BadRequest($"Não autenticado :/");
            }

            

        }

        [HttpGet]
        [Route("auth")]
        [Authorize()]
        public string Test() => $"Autorizado - {User.Identity.Name}";
    }
}
 