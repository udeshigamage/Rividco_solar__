using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IProjectServices
    {
        Task<(IEnumerable<Project>,int Totalcount)> GetAllAsync(int page=1,int pagesize=10);

        Task<Project> GetIdByAsync(int id);

        Task<Project> AddAsync(Project project);

        Task<Project> UpdateAsync(int id, Project updatedproject);

        Task<bool> DeleteAsync(int id);
    }
}
