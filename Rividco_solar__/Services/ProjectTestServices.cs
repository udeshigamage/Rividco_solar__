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
        public async Task<(List<Projecttest> tasks, int totalcount)> GetByProjectIdAsync(int projectId, int page, int pagesize)
        {
            var query = _dbcontext.Projecttest.Where(c => c.Project_ID == projectId);
            var totalcount = await query.CountAsync();
            var tasks = await query
                                 .Skip((page - 1) * pagesize)
                                 .Take(pagesize)
                                 .ToListAsync();

            return (tasks, totalcount);
        }

        public async Task<(List<Projecttest> projecttest, int totalcount)> GetAllAsync(int page, int pagesize)
        {
            var query = _dbcontext.Projecttest
                                  .Include(v => v.Project).ThenInclude(v => v.customer);

            var totalcount = await query.CountAsync();
            var projecttest = await query
                                 .Skip((page - 1) * pagesize)
                                 .Take(pagesize)
                                 .ToListAsync();

            return (projecttest, totalcount);
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
