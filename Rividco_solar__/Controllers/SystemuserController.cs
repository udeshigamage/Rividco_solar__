using Microsoft.AspNetCore.Mvc;
using Rividco_solar__.Models;
using Rividco_solar__.Services;

namespace Rividco_solar__.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemuserController : ControllerBase
    {
        private readonly ISystemuserServices _systemuserServices;

        public SystemuserController(ISystemuserServices systemuserServices)
        {
           _systemuserServices = systemuserServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {
            var (systemusers, totalcount) = await _systemuserServices.GetAllAsync(page, pagesize);
            var response = new
            {
                data = systemusers,
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var systemuser = await _systemuserServices.GetIdByAsync(id);
            if (systemuser == null) return NotFound();
            return Ok(systemuser);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Systemuser systemuser)
        {
            var newsystemuser = await _systemuserServices.AddAsync(systemuser);
            return CreatedAtAction(nameof(GetById), new { id = newsystemuser.Systemuser_ID }, newsystemuser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSystemuser(int id, Systemuser systemuser)
        {
            var updatedSystemuser = await _systemuserServices.UpdateAsync(id, systemuser);

            if (updatedSystemuser == null)
            {
                return NotFound();
            }

            return Ok(updatedSystemuser);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _systemuserServices.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
