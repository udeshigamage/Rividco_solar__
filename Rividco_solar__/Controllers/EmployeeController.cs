using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rividco_solar__.Models;
using Rividco_solar__.Services;

namespace Rividco_solar__.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeservice _employeeservice;

        public EmployeeController(IEmployeeservice employeeservice)
        {
            _employeeservice = employeeservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {
            var (employees, totalcount) = await _employeeservice.GetAllAsync(page, pagesize);
            var response = new
            {
                data = employees,
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employees = await _employeeservice.GetByIdAsync(id);
            if (employees == null) return NotFound();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            var newEmployee = await _employeeservice.AddAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = newEmployee.Employee_ID }, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            var updatedEmployee = await _employeeservice.UpdateAsync(id, employee);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeservice.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
