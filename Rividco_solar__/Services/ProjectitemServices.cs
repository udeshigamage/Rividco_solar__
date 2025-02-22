using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Dbcontext;
using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public class ProjectitemServices:IProjectitemservices
    {
        private readonly AppDbcontext _dbcontext;

        public ProjectitemServices(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<(List<Projectitem> tasks, int totalcount)> GetByProjectIdAsync(int projectId, int page, int pagesize)
        {
            var query = _dbcontext.Projectitem.Where(c => c.Project_ID == projectId).Include(c => c.Project).Include(c => c.Vendoritem);
            var totalcount = await query.CountAsync();
            var tasks = await query
                                 .Skip((page - 1) * pagesize)
                                 .Take(pagesize)
                                 .ToListAsync();

            return (tasks, totalcount);
        }
        public async Task<(List<Projectitem> projectitems, int totalcount)> GetAllAsync(int page, int pagesize)
        {
            var query = _dbcontext.Projectitem
                                  .Include(v => v.Project).ThenInclude(v=>v.customer).Include(v => v.Vendoritem).ThenInclude(v=>v.Vendor);// Include Vendor data


            var totalcount = await query.CountAsync();
            var projectitems = await query
                                 .Skip((page - 1) * pagesize)
                                 .Take(pagesize)
                                 .ToListAsync();

            return (projectitems, totalcount);
        }

        public async Task<Projectitem> GetIdByAsync(int id)
        {
            var projects = await _dbcontext.Projectitem.FindAsync(id);
            if (projects == null)
            {
                return null;

            }
            return (projects);

        }

        public async Task<Projectitem> AddAsync(Projectitem project)
        {
            _dbcontext.Projectitem.Add(project);
            await _dbcontext.SaveChangesAsync();
            return (project);
        }

        public async Task<Projectitem> UpdateAsync(int id, Projectitem updatedproject)
        {
            var existingprojects = await _dbcontext.Projectitem.FindAsync(id);

            if (existingprojects == null)
            {
                return null;
            }

            existingprojects.warranty_duration = updatedproject.warranty_duration;
            existingprojects.comment = updatedproject.comment;
            existingprojects.Vendoritem = updatedproject.Vendoritem;
            existingprojects.Added_by = updatedproject.Added_by;
            existingprojects.Added_Date = updatedproject.Added_Date;
            existingprojects.serialno = updatedproject.serialno;

            await _dbcontext.SaveChangesAsync();

            return (existingprojects);


        }

        public async Task<bool> DeleteAsync(int id)
        {
            var projects = await _dbcontext.Projectitem.FindAsync(id);
            if (projects == null)
            {
                return false;
            }
            _dbcontext.Projectitem.Remove(projects);
            await _dbcontext.SaveChangesAsync();
            return true;





        }
    }
}
