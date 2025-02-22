using Microsoft.AspNetCore.Mvc;
using Rividco_solar__.Models;
using Rividco_solar__.Services;

namespace Rividco_solar__.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectCIAController : ControllerBase
    {
        private readonly IProjectCIAservices _projectCIAservices;

        public ProjectCIAController(IProjectCIAservices projectCIAservices)
        {
            _projectCIAservices = projectCIAservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {

            var (projectcia, totalcount) = await _projectCIAservices.GetAllAsync(page, pagesize);


            var response = new
            {
                data = projectcia.Select(v => new
                {
                    v.Task_ID,
                    v.Requestedby,
                    v.Urgencylevel,
                    v.category,
                    v.Assignedto,
                    v.status,
                    v.comment,
                    v.Addedby,
                    v.AddedDate,
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
            var projectcia = await _projectCIAservices.GetByIdAsync(id);
            if (projectcia == null) return NotFound();
            return Ok(projectcia);
        }

        [HttpGet("project-tasks/{projectid}")]
        public async Task<IActionResult> GetByProjectId(int projectid, int page = 1, int pagesize = 10)
        {
            var (tasks,totalcount) = await _projectCIAservices.GetByProjectIdAsync(projectid,page,pagesize);
            var response = new
            {
                data = tasks.Select(v => new
                {
                    v.Task_ID,
                    v.Requestedby,
                    v.Urgencylevel,
                    v.category,
                    v.Assignedto,
                    v.status,
                    v.comment,
                    v.Addedby,
                    v.AddedDate,

                    

                }),
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskCIA projectcia)
        {
            var newprojectcia = await _projectCIAservices.AddAsync(projectcia);
            return CreatedAtAction(nameof(GetById), new { id = newprojectcia.Task_ID }, newprojectcia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updateprojecttest(int id, TaskCIA projecttest)
        {
            var updatedprojecttest = await _projectCIAservices.UpdateAsync(id, projecttest);

            if (updatedprojecttest == null)
            {
                return NotFound();
            }

            return Ok(updatedprojecttest);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projectCIAservices.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
