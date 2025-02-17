using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Dbcontext;
using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public class SystemuserServices : ISystemuserServices
    {
        private readonly AppDbcontext _dbcontext;

        public SystemuserServices(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<(IEnumerable<Systemuser>, int Totalcount)>GetAllAsync(int page=1,int pagesize=10)
            {
            var Totalcount = await _dbcontext.Systemusers.CountAsync();
            var systemuser = await _dbcontext.Systemusers.Skip((page-1)* pagesize).Take(pagesize).ToListAsync();
            return (systemuser, Totalcount);
            }

        public async Task<Systemuser> GetIdByAsync(int id)
        {
            var systemuser =await _dbcontext.Systemusers.FindAsync(id);
            return (systemuser);
        }

        public async Task<Systemuser>AddAsync(Systemuser systemuser)
        {
            await _dbcontext.Systemusers.AddAsync(systemuser);
            _dbcontext.SaveChanges();
            return (systemuser);
        }

        public async Task<Systemuser> UpdateAsync(int id, Systemuser updatedsystemuser)
        {
            var existingsystemuser = await _dbcontext.Systemusers.FindAsync(id);
            if(existingsystemuser == null)
            {
                return null;
            }
            existingsystemuser.email = updatedsystemuser.email;
            existingsystemuser.mobileno = updatedsystemuser.mobileno;
            existingsystemuser.username = updatedsystemuser.username;
            existingsystemuser.comment = updatedsystemuser.comment;
            existingsystemuser.Address = updatedsystemuser.Address;
            existingsystemuser.FirstName = updatedsystemuser.FirstName;
            existingsystemuser.LastName = updatedsystemuser.LastName;
            existingsystemuser.Role = updatedsystemuser.Role;
            await _dbcontext.SaveChangesAsync();

            return (existingsystemuser);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var systemuser=await _dbcontext.Systemusers.FindAsync(id);
            if(systemuser==null)
            {
                return false;
            }
             _dbcontext.Systemusers.Remove(systemuser);
            await _dbcontext.SaveChangesAsync();
            return true;

        }


    }


   
}
