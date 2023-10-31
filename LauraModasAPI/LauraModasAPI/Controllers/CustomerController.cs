using AutoMapper;
using LauraModasAPI.Dtos.CustomerDtos;
using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LauraModasAPI.Controllers
{

    [ApiController]
    [Route("v1/LauraModas/Customers")]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerServices _services;


        public CustomerController(ICustomerServices services)
        {
            this._services = services;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                List<ReadCustomerDto> customersView = await _services.GetCustomers();

                if (customersView == null)
                {
                    return NotFound();
                }

                return Ok(customersView);

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("getCustomerById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            try
            {
                ReadCustomerDto customerView = await _services.GetCustomer(id);

                if (customerView == null)
                {
                    return NotFound();
                }

                return Ok(customerView);

            } catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost]
        [Route("getCustomerByName")]
        [Authorize]
        public async Task<IActionResult> GetCustomerByName([FromBody] GetCustomerForNameDto customer)
        {
            try
            {
                List<ReadCustomerDto> customersView = await _services.GetCustomerByName(customer.Name);

                if (customersView == null)
                {
                    return NotFound();
                }

                return Ok(customersView);

            } catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost]
        [Route("postCustomer")]
        [Authorize]
        public async Task<IActionResult> PostCustomer([FromBody] CreateCustomerDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                ReadCustomerDto customerView = await _services.PostCustomer(request);

                if(customerView == null)
                {
                    return BadRequest();
                }

                return Created($"v1/LauraModas/Customers/getCustomer/{customerView.Id}", customerView);

            } catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPut]
        [Route("alterCustomer/{id}")]
        [Authorize]
        public async Task<IActionResult> AlterCustomer([FromRoute] int id, [FromBody] AlterCustomerDto request)
        {
            try
            {
                ReadCustomerDto customerView = await _services.AlterCustomer(id, request);

                if (customerView == null)
                {
                    return BadRequest();
                }

                return Created($"v1/LauraModas/Customers/{customerView.Id}", customerView);
            } catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpDelete]
        [Route("deleteCustomer/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                bool delete = await _services.DeleteCustomer(id);

                return Ok(delete);

            } catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
