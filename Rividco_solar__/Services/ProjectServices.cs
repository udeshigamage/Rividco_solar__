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

        public async Task<(IEnumerable<Project>,int Totalcount)> GetAllAsync(int page=1,int pagesize=10)
        
        {
            var Totalcount = await _dbcontext.Projects.CountAsync();
            var project =  await _dbcontext.Projects.Skip((page-1)*pagesize).Take(pagesize).ToListAsync();
            return (project,Totalcount);

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
            existingprojects.description = updatedproject.description;
            existingprojects.location = updatedproject.location;
            existingprojects.Address =updatedproject.Address;
            existingprojects.estimatedcost = updatedproject.estimatedcost;  
            existingprojects.Commissioneddate= updatedproject.Commissioneddate; 
            existingprojects.referencedby = updatedproject.referencedby;
            existingprojects.startdate = updatedproject.startdate;
            existingprojects.warranty_period =updatedproject.warranty_period;   

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
