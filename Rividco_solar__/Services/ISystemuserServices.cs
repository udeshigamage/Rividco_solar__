using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public interface ISystemuserServices
    {
        Task<string> RegisterUser(SystemuserDTO systemuser);
        Task<string> LoginUser(LoginDTO systemuser);
        string GenerateJwtToken(Systemuser systemuser);
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);

         Task<(IEnumerable<Systemuser> systemuser, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10);
    }
}
