using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IVendorServices
    {
        Task<(IEnumerable<Vendor> vendors, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10);

        Task<Vendor> GetByIdAsync(int id);

        Task<Vendor> AddAsync(Vendor vendor);

        Task<Vendor> UpdateAsync(int id,Vendor updatedvendors);

        Task<bool> DeleteAsync(int id);
    }
}
