using Microsoft.AspNetCore.Mvc;
using Rividco_solar__.Models;
using Rividco_solar__.Services;

namespace Rividco_solar__.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendoritemController : ControllerBase
    {
        private readonly IVendoritemServices _vendoritemServices;

        public VendoritemController(IVendoritemServices vendoritemServices)
        {
            _vendoritemServices = vendoritemServices;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {
            // Fetch Vendoritems with associated Vendor
            var (Vendoritems, totalcount) = await _vendoritemServices.GetAllAsync(page, pagesize);

            // Shape the response
            var response = new
            {
                data = Vendoritems.Select(v => new
                {
                    v.Vendoritem_ID,
                    v.item_name,
                    v.price,
                    v.Warranty_duration,
                    v.comment,
                    v.capacity,
                    v.Vendor_ID,
                    v.product_code,
                    v.brand,
                    v.Lastupdatedby,
                    v.Lastupdatedtime,
                    // Vendor details fetched using Vendor_ID
                    vendor = new
                    {
                        v.Vendor.Vendor_ID,
                        v.Vendor.FirstName,
                        v.Vendor.LastName,
                        v.Vendor.Email,
                        v.Vendor.mobileno,
                        v.Vendor.officeno,
                        v.Vendor.comment,
                        v.Vendor.Address,
                        v.Vendor.category,
                        v.Vendor.Lastupdatedtime,
                        v.Vendor.Lastupdatedby
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
            var Vendoritems = await _vendoritemServices.GetByIdAsync(id);
            if (Vendoritems == null) return NotFound();
            return Ok(Vendoritems);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Vendoritem vendoritem)
        {
            var newVendoritems = await _vendoritemServices.AddAsync(vendoritem);
            return CreatedAtAction(nameof(GetById), new { id = newVendoritems.Vendoritem_ID }, newVendoritems);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendoritems(int id, Vendoritem vendoritem)
        {
            var updatedvendoritem = await _vendoritemServices.UpdateAsync(id, vendoritem);

            if (updatedvendoritem == null)
            {
                return NotFound();
            }

            return Ok(updatedvendoritem);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _vendoritemServices.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
