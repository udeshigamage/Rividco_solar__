using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Dbcontext;
using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public class ProjectTestServices:IProjecttestservices
    {
        private readonly AppDbcontext _dbcontext;

        public ProjectTestServices(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<(IEnumerable<Projecttest>, int Totalcount)> GetAllAsync(int page = 1, int pagesize = 10)

        {
            var Totalcount = await _dbcontext.Projecttest.CountAsync();
            var projecttest = await _dbcontext.Projecttest.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (projecttest, Totalcount);

        }

        public async Task<Projecttest> GetIdByAsync(int id)
        {
            var projecttest = await _dbcontext.Projecttest.FindAsync(id);
            if (projecttest == null)
            {
                return null;

            }
            return (projecttest);

        }

        public async Task<Projecttest> AddAsync(Projecttest projecttest)
        {
            _dbcontext.Projecttest.Add(projecttest);
            await _dbcontext.SaveChangesAsync();
            return (projecttest);
        }

        public async Task<Projecttest> UpdateAsync(int id, Projecttest updatedprojecttest)
        {
            var existingprojecttest = await _dbcontext.Projecttest.FindAsync(id);

            if (existingprojecttest == null)
            {
                return null;
            }

            existingprojecttest.comment = updatedprojecttest.comment;
            existingprojecttest.result = updatedprojecttest.result;
            existingprojecttest.test_name = updatedprojecttest.test_name;
            existingprojecttest.Conducted_by = updatedprojecttest.Conducted_by;
            existingprojecttest.Conducted_date = updatedprojecttest.Conducted_date;
            ;
            await _dbcontext.SaveChangesAsync();

            return (existingprojecttest);


        }

        public async Task<bool> DeleteAsync(int id)
        {
            var projecttest = await _dbcontext.Projecttest.FindAsync(id);
            if (projecttest == null)
            {
                return false;
            }
            _dbcontext.Projecttest.Remove(projecttest);
            await _dbcontext.SaveChangesAsync();
            return true;





        }
    }
}
