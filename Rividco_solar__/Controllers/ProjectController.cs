using Microsoft.AspNetCore.Mvc;
using Rividco_solar__.Models;
using Rividco_solar__.Services;

namespace Rividco_solar__.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController: ControllerBase
    {
        private readonly IProjectServices _projectServices;

        public ProjectController (IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {
            // Fetch Vendoritems with associated Vendor
            var (project, totalcount) = await _projectServices.GetAllAsync(page, pagesize);

            // Shape the response
            var response = new
            {
                data = project.Select(v => new
                {
                    v.Project_ID,
                    v.location,
                    v.warranty_period,
                    v.referencedby,
                    v.comment,
                    v.Address,
                    v.Customer_ID,
                    v.startdate,
                    v.estimatedcost,
                   
                    v.Coordinator_ID,
                    v.status,
                    
                    v.Lastupdatedby,
                    v.Lastupdatedtime,
                    // Vendor details fetched using Vendor_ID
                    Customer= new
                    {
                        v.customer.LastName,
                        v.customer.FirstName,
                        v.customer.email,
                        v.customer.mobileno,
                        v.customer.officeno,
                        v.customer.comment,
                        v.customer.Address,
                        v.customer.category,
                        v.customer.Lastupdatedtime,
                        v.customer.Lastupdatedby
                    }
                }),
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProjects(int id)
        {
            var projects = await _projectServices.GetIdByAsync(id); 
            if (projects == null) return NotFound();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Project project)
        {
            var newProject = await _projectServices.AddAsync(project);
            return CreatedAtAction(nameof(GetByIdProjects), new { id = newProject.Project_ID }, newProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            var updatedProject = await _projectServices.UpdateAsync(id, project);

            if (updatedProject == null)
            {
                return NotFound();
            }

            return Ok(updatedProject);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjects(int id)
        {
            var result = await _projectServices.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
