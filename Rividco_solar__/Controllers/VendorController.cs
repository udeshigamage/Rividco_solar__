using Microsoft.AspNetCore.Mvc;
using Rividco_solar__.Models;
using Rividco_solar__.Services;

namespace Rividco_solar__.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly IVendorServices _vendorServices;

        public VendorController(IVendorServices vendorServices)
        {
            _vendorServices = vendorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {
            var (vendors, totalcount) = await _vendorServices.GetAllAsync(page, pagesize);
            var response = new
            {
                data = vendors,
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vendors = await _vendorServices.GetByIdAsync(id);
            if (vendors == null) return NotFound();
            return Ok(vendors);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Vendor vendor)
        {
            var newVendor = await _vendorServices.AddAsync(vendor);
            return CreatedAtAction(nameof(GetById), new { id = newVendor.Vendor_ID }, newVendor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendor(int id, Vendor vendor)
        {
            var updatedvendor = await _vendorServices.UpdateAsync(id, vendor);

            if (updatedvendor == null)
            {
                return NotFound();
            }

            return Ok(updatedvendor);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _vendorServices.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
