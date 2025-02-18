using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IProjectCIAservices
    {
        Task<(List<TaskCIA> projectcia, int totalcount)> GetAllAsync(int page, int pagesize);

        Task<TaskCIA> GetByIdAsync(int id);
        Task<(List<TaskCIA> tasks, int totalcount)> GetByProjectIdAsync(int projectId, int page, int pagesize);
        Task<TaskCIA> AddAsync(TaskCIA task);

        Task<TaskCIA> UpdateAsync(int id, TaskCIA updatedtask);

        Task<bool> DeleteAsync(int id);
    }
}
