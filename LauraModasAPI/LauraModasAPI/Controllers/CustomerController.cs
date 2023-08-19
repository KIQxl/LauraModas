using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.AspNetCore.Mvc;

namespace LauraModasAPI.Controllers
{

    [ApiController]
    [Route("v1/LauraModas/Customer")]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerServices _services;

        public CustomerController(ICustomerServices services)
        {
            this._services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                List<CustomerModel> customers = await _services.GetCustomers();

                return Ok(customers);

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("customer/{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            try
            {
                CustomerModel customer = await _services.GetCustomer(id);

                return Ok(customer);
            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [HttpPost]
        [Route("postCustomer")]
        public async Task<IActionResult> PostCustomer([FromBody] CustomerModel customer)
        {
            try
            {   
                await _services.PostCustomer(customer);

                return Created($"v1/LauraModas/Customer/{customer.Id}", customer);

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [HttpPut]
        [Route("alterCustomer/{id}")]
        public async Task<IActionResult> AlterCustomer([FromRoute] int id, [FromBody] CustomerModel customer)
        {
            try
            {
                CustomerModel customerDb = await _services.GetCustomer(id);

                await _services.AlterCustomer(id, customer);

                return Created($"v1/LauraModas/Customer/{customerDb.Id}", customer);
            } catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [HttpDelete]
        [Route("deleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                bool delete = await _services.DeleteCustomer(id);

                return Ok(delete);

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
