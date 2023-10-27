using LauraModasAPI.Dtos.LotDtos;
using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LauraModasAPI.Controllers
{
    [ApiController]
    [Route("v1/LauraModas/Lots")]
    public class LotController : ControllerBase
    {
        public readonly ILotServices _lotServices;

        public LotController(ILotServices services)
        {
            this._lotServices = services;            
        }

        [HttpGet]
        [Route("getLots")]
        [Authorize]
        public async Task<IActionResult> GetLots() 
        {
            try
            {
                List<LotModel> lots = await _lotServices.GetLots();

                return Ok(lots);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("createLot")]
        [Authorize]
        public async Task<IActionResult> CreateLot(CreateLotDto request)
        {
            try
            {
                await _lotServices.CreateLot(request);

                return Ok();

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

    }
}
