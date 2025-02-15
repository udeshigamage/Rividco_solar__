using Microsoft.AspNetCore.Mvc;

using Rividco_solar__.Models;
using Rividco_solar__.Services;

namespace Rividco_solar__.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices  _customerServices;

        public CustomerController(ICustomerServices customerService)
        {
            _customerServices = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {
            var (customers, totalcount) = await _customerServices.GetAllAsync(page, pagesize);
            var response = new
            {
                data = customers,
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customers = await _customerServices.GetByIdAsync(id);
            if (customers == null) return NotFound();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {
            var newCustomer = await _customerServices.AddAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = newCustomer.Customer_ID }, newCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Customer customer)
        {
            var updatedEmployee = await _customerServices.UpdateAsync(id, customer);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerServices.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
