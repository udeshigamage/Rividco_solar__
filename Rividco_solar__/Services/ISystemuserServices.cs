using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface ISystemuserServices
    {
        Task<(IEnumerable<Systemuser>, int Totalcount)> GetAllAsync(int page = 1, int pagesize = 10);

        Task<Systemuser> GetIdByAsync(int id);

        Task<Systemuser> AddAsync(Systemuser user);

        Task<Systemuser> UpdateAsync(int id,Systemuser user);

        Task<bool> DeleteAsync(int id);
    }
}
