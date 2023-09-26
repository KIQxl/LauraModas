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

            try
            {
                IdentityResult result = await _userServices.CreateUser(request);

                if (!result.Succeeded)
                {
                    return BadRequest("Falha ao criar usuário");
                }

                return Ok(new
                {
                    message = "Usuário Cadastrado",
                    result = result
                });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

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

                if (user == null) 
                {
                    return BadRequest();
                }

                return Ok(new
                {
                    user,
                    token
                });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
 