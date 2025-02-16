using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IProjectCIAservices
    {
        Task<(IEnumerable<TaskCIA> tasks, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10);

        Task<TaskCIA> GetByIdAsync(int id);

        Task<TaskCIA> AddAsync(TaskCIA task);

        Task<TaskCIA> UpdateAsync(int id, TaskCIA updatedtask);

        Task<bool> DeleteAsync(int id);
    }
}
