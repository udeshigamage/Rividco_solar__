using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IProjecttestservices
    {
        Task<(IEnumerable<Projecttest>, int Totalcount)> GetAllAsync(int page = 1, int pagesize = 10);

        Task<Projecttest> GetIdByAsync(int id);

        Task<Projecttest> AddAsync(Projecttest projecttest);

        Task<Projecttest> UpdateAsync(int id, Projecttest updatedprojecttest);

        Task<bool> DeleteAsync(int id);
    }
}
