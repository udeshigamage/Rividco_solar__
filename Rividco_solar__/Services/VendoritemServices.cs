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

        public async Task<(IEnumerable<Vendoritem> vendoritem, int Totalcount)> GetAllAsync(int pagesize = 10, int page = 1)
        {
            var Totalcount = await _dbcontext.Vendoritem.CountAsync();
            var vendoritems = await _dbcontext.Vendoritem.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (vendoritems, Totalcount);

        }

        public async Task<Vendoritem> GetByIdAsync(int id)
        {
            var vendoritems = await _dbcontext.Vendoritem.FindAsync(id);

            return (vendoritems);

        }

        public async Task<Vendoritem> AddAsync(Vendoritem vendoritem)
        {
            _dbcontext.Vendoritem.Add(vendoritem);
            _dbcontext.SaveChanges();
            return (vendoritem);
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
            
            return (existingvendoritems);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vendoritems = await _dbcontext.Vendoritem.FindAsync(id);
            if (vendoritems == null)
            { return false; }
            _dbcontext.Vendoritem.Remove(vendoritems);
            return true;
        }
    }
}
