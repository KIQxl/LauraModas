using AutoMapper;
using LauraModasAPI.Data;
using LauraModasAPI.Dtos.BuyDtos;
using LauraModasAPI.Models;
using LauraModasAPI.Models.Enums;
using LauraModasAPI.Services.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LauraModasAPI.Controllers
{
    [ApiController]
    [Route("v1/LauraModas/Buys")]
    public class BuyController : ControllerBase
    {
        readonly IBuyServices _services;

        public BuyController(IBuyServices services)
        {
            this._services = services;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBuys()
        {
            try
            {
                List<ReadBuyDto> buysView = await _services.GetBuys();

                return Ok(buysView);

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

        }

        [HttpGet]
        [Route("getBuy/{id}")]
        [Authorize]
        public async Task<IActionResult> GetBuy([FromRoute] int id)
        {
            try
            {
                ReadBuyDto buyView = await _services.GetBuy(id);

                return Ok(buyView);

            } catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("getBuyByName")]
        [Authorize]
        public async Task<IActionResult> GetBuyByName(GetBuyByNameDto buy)
        {
            try
            {

                List<ReadBuyDto> buysView = await _services.GetBuysByName(buy.Name);

                return Ok(buysView);

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [HttpPost]
        [Route("postBuy")]
        [Authorize]
        public async Task<IActionResult> PostBuy([FromBody] CreateBuyDto request, [FromServices] ICustomerServices _customerServices)
        {
            try
            {
                CustomerModel customer = await _customerServices.GetCustomerModelForId(request.CustomerModelId);

                if (customer == null)
                {
                    return NotFound();
                }

                ReadBuyDto buyView = await _services.PostBuy(request);

                return Created($"v1/LauraModas/Buy/getBuy/{buyView.Id}", buyView);

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [HttpPut]
        [Route("alterBuy/{id}")]
        [Authorize]
        public async Task<IActionResult> AlterBuy([FromRoute] int id, [FromBody] AlterBuyDto request)
        {
            try
            {
                ReadBuyDto buyView = await _services.AlterBuy(id, request);

                return Created($"v1/LauraModas/Buy/getBuy/{buyView.Id}", buyView);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [HttpDelete]
        [Route("deleteBuy/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBuy([FromRoute] int id)
        {
            try
            {
                bool delete = await _services.DeleteBuy(id);
                return Ok(delete);
            } catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
