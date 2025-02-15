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

        public async Task<(IEnumerable<Vendor> vendors, int Totalcount)> GetAllAsync(int pagesize = 10, int page = 1)
        {
            var Totalcount = await _dbcontext.Vendor.CountAsync();
            var vendors = await _dbcontext.Vendor.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (vendors, Totalcount);

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

        public async Task<Vendor> UpdateAsync(int id, Vendor updatedvendors)
        {
            var existingvendors = await _dbcontext.Vendor.FindAsync(id);

            if (existingvendors == null)
            {
                return null;
            }

            existingvendors.comment = updatedvendors.comment;
            existingvendors.officeno = updatedvendors.officeno;
            existingvendors.Email = updatedvendors.Email;
            existingvendors.mobileno = updatedvendors.mobileno;
            existingvendors.Address = updatedvendors.Address;
            existingvendors.category = updatedvendors.category;
            existingvendors.FirstName = updatedvendors.FirstName;
            existingvendors.LastName = updatedvendors.LastName;

            return (existingvendors);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vendors = await _dbcontext.Vendor.FindAsync(id);
            if (vendors == null)
            { return false; }
            _dbcontext.Vendor.Remove(vendors);
            return true;
        }
    }
}
