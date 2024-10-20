namespace CustomersWebAPI.Controllers
{
    using System.Net.Mime;
    using CommonModels;
    using Microsoft.AspNetCore.Mvc;
    using ServiceLayer.Interfaces;
    using System.Threading.Tasks;

    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _customerService.GetAll();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all current customers");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customer = await _customerService.GetById(id);

                if (customer == null)
                {
                    return NotFound(new { message = "Customer not found." });
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching customer with Id: {id}");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("Save")]
        public async Task<IActionResult> SaveCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return NoContent();
                }
                
                await _customerService.Update(customer);
                return Ok(new { message = "Customer saved successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred saving customer with Id: {customer.Id}");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("Delete")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _customerService.GetById(id);

                if (customer == null)
                {
                    return NotFound(new { message = "Customer not found." });
                }

                await _customerService.Delete(id);
                return Ok(new { message = "Customer deleted successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred deleting customer with Id: {id}");
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
