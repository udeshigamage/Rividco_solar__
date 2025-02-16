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
        public async Task<IActionResult> GetAllProjects(int page = 1, int pagesize = 10)
        {
            var (projects, Totalcount) = await _projectServices.GetAllAsync(page, pagesize);
            var response = new
            {
                data = projects,
                totalItems = Totalcount,
                totalPages = (int)Math.Ceiling((double)Totalcount / pagesize),
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
