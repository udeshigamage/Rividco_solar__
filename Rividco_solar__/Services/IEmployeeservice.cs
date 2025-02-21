using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IEmployeeservice
    {
        Task<(IEnumerable<Employee> employee, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10);

        Task<Employee> GetByIdAsync(int id);

        Task<Employee> AddAsync(Employee employe);

        Task<Employee> UpdateAsync(int id, Employee updatedEmployee);

        Task<bool> DeleteAsync(int id);
    }
}
