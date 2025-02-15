using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IVendoritemServices
    {
        Task<(IEnumerable<Vendoritem>, int Totalcount)> GetAllAsync(int page=1,int pagesize=10);
        Task<Vendoritem> GetByIdAsync(int id);

        Task<Vendoritem> AddAsync(Vendoritem vendoritem);
        Task<Vendoritem> UpdateAsync(int id,Vendoritem updatedvendoritem);

        Task<bool> DeleteAsync(int id);


    }
}
