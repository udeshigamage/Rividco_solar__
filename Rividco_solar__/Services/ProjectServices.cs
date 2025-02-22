using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Dbcontext;
using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public class ProjectServices:IProjectServices
    {
        private readonly AppDbcontext _dbcontext;

        public ProjectServices (AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<(List<Project> project, int totalcount)> GetAllAsync(int page, int pagesize)
        {
            var query = _dbcontext.Projects
                                  .Include(v => v.customer); // Include Vendor data


            var totalcount = await query.CountAsync();
            var project = await query
                                 .Skip((page - 1) * pagesize)
                                 .Take(pagesize)
                                 .ToListAsync();

            return (project, totalcount);
        }

        public async Task<Project> GetIdByAsync(int id)
        {
           var projects= await _dbcontext.Projects.FindAsync(id);
            if(projects == null)
            {
                return null;

            }
            return (projects);

        }

        public async Task<Project> AddAsync(Project project)
        {
             _dbcontext.Projects.Add(project);
            await _dbcontext.SaveChangesAsync();
            return (project);
        }

        public async Task<Project> UpdateAsync(int id,Project updatedproject)
        {
            var existingprojects = await _dbcontext.Projects.FindAsync(id);

            if(existingprojects == null)
            {
                return null;
            }

            existingprojects.status = updatedproject.status;
            existingprojects.comment = updatedproject.comment;
            existingprojects.Customer_ID=updatedproject.Customer_ID;
           
            existingprojects.location = updatedproject.location;
            existingprojects.Address =updatedproject.Address;
            existingprojects.estimatedcost = updatedproject.estimatedcost;  
           existingprojects.Coordinator_ID = updatedproject.Coordinator_ID;
            existingprojects.referencedby = updatedproject.referencedby;
            existingprojects.startdate = updatedproject.startdate;
            existingprojects.warranty_period =updatedproject.warranty_period;
            await _dbcontext.SaveChangesAsync();

            return (existingprojects);


        }

        public async Task<bool> DeleteAsync(int id)
        {
            var projects = await _dbcontext.Projects.FindAsync(id);
            if(projects == null)
            {
                return false;
            }
            _dbcontext.Projects.Remove(projects);
            await _dbcontext.SaveChangesAsync();
            return true;





        }
    }
}
