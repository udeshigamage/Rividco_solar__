using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface ICustomerServices
    {

        Task<(IEnumerable<Customer> customers, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10);

        Task<Customer> GetByIdAsync(int id);

        Task<Customer> AddAsync (Customer customer);

        Task<Customer> UpdateAsync(int id,Customer customer);

        Task<bool> DeleteAsync(int id);

    }
}
