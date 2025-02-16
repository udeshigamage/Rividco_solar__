using Microsoft.AspNetCore.Mvc;
using Rividco_solar__.Models;
using Rividco_solar__.Services;

namespace Rividco_solar__.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectitemController : ControllerBase
    {
        private readonly IProjectitemservices _projectitemservices;

        public ProjectitemController(IProjectitemservices projectitemservices)
        {
            _projectitemservices = projectitemservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {
            var (projectitem, Totalcount) = await _projectitemservices.GetAllAsync(page, pagesize);
            var response = new
            {
                data = projectitem,
                totalItems = Totalcount,
                totalPages = (int)Math.Ceiling((double)Totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var projectitem = await _projectitemservices.GetIdByAsync(id);
            if (projectitem == null) return NotFound();
            return Ok(projectitem);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Projectitem projectitem)
        {
            var newProjectitem = await _projectitemservices.AddAsync(projectitem);
            return CreatedAtAction(nameof(GetById), new { id = newProjectitem.Project_ID }, newProjectitem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, Projectitem projectitem)
        {
            var updatedProjectitem = await _projectitemservices.UpdateAsync(id, projectitem);

            if (updatedProjectitem == null)
            {
                return NotFound();
            }

            return Ok(updatedProjectitem);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projectitemservices.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
