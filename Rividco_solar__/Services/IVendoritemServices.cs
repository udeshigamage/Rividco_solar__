using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IVendoritemServices
    {
        Task<(List<Vendoritem> Vendoritems, int totalcount)> GetAllAsync(int page, int pagesize);
        Task<Vendoritem> GetByIdAsync(int id);

        Task<Vendoritem> AddAsync(Vendoritem vendoritem);
        Task<Vendoritem> UpdateAsync(int id,Vendoritem updatedvendoritem);

        Task<bool> DeleteAsync(int id);


    }
}
