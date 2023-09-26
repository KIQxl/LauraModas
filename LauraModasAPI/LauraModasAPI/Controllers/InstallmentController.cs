using LauraModasAPI.Dtos.InstallmentDtos;
using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.AspNetCore.Mvc;

namespace LauraModasAPI.Controllers
{
    [ApiController]
    [Route("v1/LauraModas/Installment")]
    public class InstallmentController : ControllerBase
    {
        public readonly IInstallmentServices _InstallmentServices;
        public InstallmentController(IInstallmentServices installmentServices)
        {
            this._InstallmentServices = installmentServices;
        }

        [HttpPost]
        [Route("parcel")]
        public async Task<IActionResult> Parcel([FromBody] CreateInstallment request)
        {
            try
            {
                ReadInstallment installment = await _InstallmentServices.Parcel(request);

                if (installment == null)
                {
                    return BadRequest();
                }

                return Ok(installment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("pay/{id}")]
        public async Task<IActionResult> Pay([FromRoute] int id)
        {
            try
            {
                ReadInstallment installment = await _InstallmentServices.PayInstallment(id);

                if (installment == null)
                {
                    return NotFound();
                }

                return Ok(installment);

            } catch (Exception ex)
            {
                throw new Exception($"Houve um erro no pagamento: {ex.Message}");
            }
            
        }

        [HttpGet]
        [Route("getInstallment/{id}")]
        public async Task<IActionResult> GetInstallment([FromRoute] int id)
        {
            try
            {
                ReadInstallment installment = await _InstallmentServices.GetInstallmentForId(id);

                if (installment == null) return NotFound();

                return Ok(installment);
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message} aaaa");
            }
        }
    }
}
