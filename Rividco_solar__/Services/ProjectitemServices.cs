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

        public async Task<(IEnumerable<Projectitem>, int Totalcount)> GetAllAsync(int page = 1, int pagesize = 10)

        {
            var Totalcount = await _dbcontext.Projectitem.CountAsync();
            var project = await _dbcontext.Projectitem.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (project, Totalcount);

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
