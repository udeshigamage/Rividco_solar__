using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IProjecttestservices
    {
        Task<(List<Projecttest> projecttest, int totalcount)> GetAllAsync(int page, int pagesize);
        Task<(List<Projecttest> tasks, int totalcount)> GetByProjectIdAsync(int projectId, int page, int pagesize);
        Task<Projecttest> GetIdByAsync(int id);

        Task<Projecttest> AddAsync(Projecttest projecttest);

        Task<Projecttest> UpdateAsync(int id, Projecttest updatedprojecttest);

        Task<bool> DeleteAsync(int id);
    }
}
