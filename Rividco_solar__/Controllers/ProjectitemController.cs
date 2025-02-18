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
            // Fetch Vendoritems with associated Vendor
            var (projectitem, totalcount) = await _projectitemservices.GetAllAsync(page, pagesize);

            // Shape the response
            var response = new
            {
                data = projectitem.Select(v => new
                {
                    v.warranty_duration,
                    v.Added_by,
                    v.Added_Date,
                    v.comment,
                    v.serialno,
                    v.Projectitem_ID,
                    v.Project_ID,
                    
                    // Vendor details fetched using Vendor_ID
                  
                    Project = new
                    {
                        v.Project.Project_ID,
                        v.Project.Coordinator_ID,
                        v.Project.Address,
                        v.Project.comment,
                        v.Project.Commissioneddate,
                        v.Project.customer.FirstName,
                        v.Project.estimatedcost,
                        v.Project.startdate,
                        v.Project.status,
                        v.Project.location
                    },
                    vendoritem = new
                    {
                        v.Vendoritem.Vendoritem_ID,
                        v.Vendoritem.brand,
                        v.Vendoritem.capacity,
                        v.Vendoritem.comment,
                        v.Vendoritem.item_name,
                        v.Vendoritem.price,
                        v.Vendoritem.Warranty_duration,
                        v.Vendoritem.Vendor.FirstName,
                       
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
