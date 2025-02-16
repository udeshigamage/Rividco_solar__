using Microsoft.AspNetCore.Mvc;
using Rividco_solar__.Models;
using Rividco_solar__.Services;

namespace Rividco_solar__.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjecttestController : ControllerBase
    {
        private readonly IProjecttestservices _projecttestservices;

        public ProjecttestController(IProjecttestservices projecttestservices)
        {
            _projecttestservices= projecttestservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {
            var (projecttest, totalcount) = await _projecttestservices.GetAllAsync(page, pagesize);
            var response = new
            {
                data = projecttest,
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var projecttest = await _projecttestservices.GetIdByAsync(id);
            if (projecttest == null) return NotFound();
            return Ok(projecttest);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Projecttest projecttest)
        {
            var newprojecttest = await _projecttestservices.AddAsync(projecttest);
            return CreatedAtAction(nameof(GetById), new { id = newprojecttest.ProjectTest_ID }, newprojecttest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updateprojecttest(int id,Projecttest  projecttest)
        {
            var updatedprojecttest = await _projecttestservices.UpdateAsync(id, projecttest);

            if (updatedprojecttest == null)
            {
                return NotFound();
            }

            return Ok(updatedprojecttest);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projecttestservices.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
