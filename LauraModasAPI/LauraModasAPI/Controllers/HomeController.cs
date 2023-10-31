using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LauraModasAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Home()
        {
            return Ok("Deus é Bom demais");
        }
    }
}
