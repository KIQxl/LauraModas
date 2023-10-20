using LauraModasAPI.Dtos.BuyDtos;
using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LauraModasAPI.Controllers
{
    [ApiController]
    [Route("v1/LauraModas/BuyLogs")]
    public class BuyLogsController : ControllerBase
    {
        public readonly IBuyLogServices _buyLogsServices;

        public BuyLogsController(IBuyLogServices buyLogServices)
        {
            this._buyLogsServices = buyLogServices;
        }


        [HttpGet]
        [Route("getLogs")]
        [Authorize]
        public async Task<IActionResult> GetLogs() 
        {
            try
            {
                List<BuyLogModel> logs = await _buyLogsServices.GetLogs();

                return Ok(logs);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("getLogsByDate")]
        [Authorize]
        public async Task<IActionResult> GetLogsByDateRange([FromBody] GetBuyByDateRangeDto dateRange)
        {
            try
            {
                List<BuyLogModel> logs = await _buyLogsServices.GetLogsByDataRange(dateRange);

                return Ok(logs);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
