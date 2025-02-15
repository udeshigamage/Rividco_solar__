namespace Rividco_solar__.Services
{
    public interface IProjectServices
    {
        Task<(IEnumerable<ProjectServices>,int Totalcount)> GetAllAsync(int page=1,int pagesize=10);

        Task<ProjectServices> GetIdByAsync(int id);

        Task<ProjectServices> AddAsync(ProjectServices service);

        Task<ProjectServices> UpdateAsync(ProjectServices service,int id);

        Task<bool> DeleteAsync(int id);
    }
}
