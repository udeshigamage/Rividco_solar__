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
                data = projecttest.Select(v => new
                {
                    v.result,
                    v.test_name,
                    v.comment,
                    v.Conducted_by,
                    v.Conducted_date,
                    v.ProjectTest_ID,
                    v.Project_ID,
                   
                   

                    

                    Project = new
                    {
                        v.Project.Project_ID,
                        v.Project.Coordinator_ID,
                        v.Project.Address,
                        v.Project.comment,
                        
                        v.Project.customer.FirstName,
                        v.Project.estimatedcost,
                        v.Project.startdate,
                        v.Project.status,
                        v.Project.location
                    }
                    
                }),
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


        [HttpGet("project-test/{projectid}")]
        public async Task<IActionResult> GetByProjectId(int projectid, int page = 1, int pagesize = 10)
        {
            var (tasks, totalcount) = await _projecttestservices.GetByProjectIdAsync(projectid, page, pagesize);
            var response = new
            {
                data = tasks.Select(v => new
                {
                    v.result,
                    v.test_name,
                    v.comment,
                    v.Conducted_by,
                    v.Conducted_date,
                    v.ProjectTest_ID,
                    v.Project_ID,



                }),
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
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
