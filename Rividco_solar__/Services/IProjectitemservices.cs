using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface IProjectitemservices
    {
        Task<(List<Projectitem> projectitems, int totalcount)> GetAllAsync(int page, int pagesize);

        Task<Projectitem> GetIdByAsync(int id);

        Task<Projectitem> AddAsync(Projectitem projectitem);

        Task<Projectitem> UpdateAsync(int id, Projectitem projectitem);

        Task<bool> DeleteAsync(int id);
    }
}
