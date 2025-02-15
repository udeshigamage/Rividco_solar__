using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface ICIAservices
    {
        Task<(IEnumerable<Task> tasks, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10);

        Task<Task> GetByIdAsync(int id);

        Task<Task> AddAsync(Task task);

        Task<Task> UpdateAsync(int id, Task task);

        Task<bool> DeleteAsync(int id);

    }
}
