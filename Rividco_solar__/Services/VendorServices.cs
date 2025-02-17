using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Dbcontext;
using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public class VendorServices : IVendorServices
    {
        private readonly AppDbcontext _dbcontext;

        public VendorServices(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;

        }

        public async Task<(IEnumerable<Vendor> vendors, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10)
        {
            var TotalCount = await _dbcontext.Vendor.CountAsync();
            var vendors = await _dbcontext.Vendor.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (vendors, TotalCount);
        }

        public async Task<Vendor> GetByIdAsync(int id)
        {
            var vendors = await _dbcontext.Vendor.FindAsync(id);

            return (vendors);

        }

        public async Task<Vendor> AddAsync(Vendor vendor)
        {
            _dbcontext.Vendor.Add(vendor);
            _dbcontext.SaveChanges();
            return (vendor);
        }

        public async Task<Vendor?> UpdateAsync(int id, Vendor updatedVendor)
        {
            // Find the employee in the database
            var existingVendor = await _dbcontext.Vendor.FindAsync(id);
            if (existingVendor == null)
            {
                return null; // Return null if the employee doesn't exist
            }

            // Update the employee fields
            existingVendor.Email = updatedVendor.Email;
            existingVendor.category = updatedVendor.category;

            existingVendor.mobileno = updatedVendor.mobileno;
            existingVendor.officeno = updatedVendor.officeno;
            existingVendor.comment = updatedVendor.comment;
            existingVendor.Address = updatedVendor.Address;
            existingVendor.FirstName = updatedVendor.FirstName;
            existingVendor.LastName = updatedVendor.LastName;





            // Save changes to the database
            await _dbcontext.SaveChangesAsync();

            return existingVendor; // Return the updated employee
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var vendors = await _dbcontext.Vendor.FindAsync(id);
            if (vendors == null) return false;

            _dbcontext.Vendor.Remove(vendors);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
