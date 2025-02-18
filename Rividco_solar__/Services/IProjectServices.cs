using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IProjectServices
    {
        Task<(List<Project> project, int totalcount)> GetAllAsync(int page, int pagesize);

        Task<Project> GetIdByAsync(int id);

        Task<Project> AddAsync(Project project);

        Task<Project> UpdateAsync(int id, Project updatedproject);

        Task<bool> DeleteAsync(int id);
    }
}
