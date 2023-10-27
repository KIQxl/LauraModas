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

                if (buysView == null)
                {
                    return NotFound();
                }

                return Ok(buysView);

            } catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
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

                if (buyView == null)
                {
                    return BadRequest("Não encontrado");
                }

                return Ok(buyView);

            } catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost]
        [Route("getBuyByCustomerName")]
        [Authorize]
        public async Task<IActionResult> GetBuyByCustomerName(GetBuyByNameDto buy)
        {
            try
            {
                List<ReadBuyDto> buysView = await _services.GetBuysByCustomerName(buy.Name);

                if (buysView == null)
                {
                    return BadRequest("Não encontrado");
                }

                return Ok(buysView);

            } catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost]
        [Route("postBuy")]
        [Authorize]
        public async Task<IActionResult> PostBuy([FromBody] CreateBuyDto request)
        {
            try
            {
                ReadBuyDto buyView = await _services.PostBuy(request);

                return Created($"v1/LauraModas/Buy/getBuy/{buyView.Id}", buyView);

            } catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
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

                if (buyView == null)
                {
                    return BadRequest("Não encontrado");
                }

                return Created($"v1/LauraModas/Buy/getBuy/{buyView.Id}", buyView);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                return BadRequest($"Houve um erro. {ex.Message}");
            }
        }

        [HttpPost]
        [Route("parcelBuy")]
        [Authorize]
        public async Task<IActionResult> ParcelBuy([FromBody] ParcelBuyDto request)
        {
            try
            {
                ReadBuyDto buy = await _services.ParcelBuy(request);

                return Ok(buy);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("payBuy/{id}")]
        [Authorize]
        public async Task<IActionResult> PayBuy([FromRoute] int id)
        {
            try
            {
                ReadBuyDto buy = await _services.PayBuy(id);

                return Ok(buy);
            } catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("getBuyByDateRange")]
        [Authorize]
        public async Task<IActionResult> GetBuyByDateRange([FromBody] GetBuyByDateRangeDto dateRange)
        {
            try
            {
                List<ReadBuyDto> buys = await _services.GetBuyByDateRange(dateRange);

                return Ok(buys);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
