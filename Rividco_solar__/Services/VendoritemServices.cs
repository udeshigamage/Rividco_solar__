using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Dbcontext;
using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public class VendoritemServices : IVendoritemServices
    {
        private readonly AppDbcontext _dbcontext;

        public VendoritemServices(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;

        }

        public async Task<(List<Vendoritem> Vendoritems, int totalcount)> GetAllAsync(int page, int pagesize)
        {
            var query = _dbcontext.Vendoritem
                                  .Include(v => v.Vendor); // Include Vendor data
                                  

            var totalcount = await query.CountAsync();
            var vendoritems = await query
                                 .Skip((page - 1) * pagesize)
                                 .Take(pagesize)
                                 .ToListAsync();

            return (vendoritems, totalcount);
        }




        public async Task<Vendoritem> GetByIdAsync(int id)
        {
            var vendoritems = await _dbcontext.Vendoritem.FindAsync(id);

            return (vendoritems);

        }

        public async Task<Vendoritem> AddAsync(Vendoritem vendoritem)
        {
            // Ensure Vendor object is not attached when adding
            vendoritem.Vendor = null;

            _dbcontext.Vendoritem.Add(vendoritem);
            await _dbcontext.SaveChangesAsync();

            return vendoritem;
        }


        public async Task<Vendoritem> UpdateAsync(int id, Vendoritem updatedvendoritems)
        {
            var existingvendoritems = await _dbcontext.Vendoritem.FindAsync(id);

            if (existingvendoritems == null)
            {
                return null;
            }

            existingvendoritems.price = updatedvendoritems.price;
            existingvendoritems.capacity = updatedvendoritems.capacity;
            existingvendoritems.comment = updatedvendoritems.comment;
            existingvendoritems.brand = updatedvendoritems.brand;
            existingvendoritems.product_code = updatedvendoritems.product_code;
            existingvendoritems.item_name = updatedvendoritems.item_name;
            existingvendoritems.Warranty_duration=updatedvendoritems.Warranty_duration;
            existingvendoritems.Vendor_ID=updatedvendoritems.Vendor_ID;

            await _dbcontext.SaveChangesAsync();

            return (existingvendoritems);

        }
       
        public async Task<bool> DeleteAsync(int id)
        {
            var vendoritems = await _dbcontext.Vendoritem.FindAsync(id);
            if (vendoritems == null)
            { return false; }
            _dbcontext.Vendoritem.Remove(vendoritems);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
