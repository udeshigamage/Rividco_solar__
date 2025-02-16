using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IProjectitemservices
    {
        Task<(IEnumerable<Projectitem>, int Totalcount)> GetAllAsync(int page = 1, int pagesize = 10);

        Task<Projectitem> GetIdByAsync(int id);

        Task<Projectitem> AddAsync(Projectitem projectitem);

        Task<Projectitem> UpdateAsync(int id, Projectitem projectitem);

        Task<bool> DeleteAsync(int id);
    }
}
