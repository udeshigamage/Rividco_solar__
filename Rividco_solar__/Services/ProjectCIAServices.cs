using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Dbcontext;
using Rividco_solar__.Models;
using System.Threading.Tasks;

namespace Rividco_solar__.Services
{
    public class ProjectCIAServices:IProjectCIAservices
    {
        private readonly AppDbcontext _context;

        public ProjectCIAServices(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<(List<TaskCIA> projectcia, int totalcount)> GetAllAsync(int page, int pagesize)
        {
            var query = _context.TaskCIA.Include(v => v.Project).ThenInclude(v => v.customer);

            var totalcount = await query.CountAsync();
            var projectcia = await query
                                 .Skip((page - 1) * pagesize)
                                 .Take(pagesize)
                                 .ToListAsync();

            return (projectcia, totalcount);
        }

        public async Task<TaskCIA> GetByIdAsync(int id)
        {
            return await _context.TaskCIA.FindAsync(id);
        }
        public async Task<(List<TaskCIA> tasks, int totalcount)> GetByProjectIdAsync(int projectId, int page, int pagesize)
        {
            var query =  _context.TaskCIA.Where(c => c.Project_ID == projectId);
            var totalcount = await query.CountAsync();
            var tasks = await query
                                 .Skip((page - 1) * pagesize)
                                 .Take(pagesize)
                                 .ToListAsync();

            return (tasks, totalcount);
        }

        public async Task<TaskCIA> AddAsync(TaskCIA task)
        {
            _context.TaskCIA.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }
        public async Task<TaskCIA> UpdateAsync(int id, TaskCIA updatedtask)
        {
            // Find the employee in the database
            var existingTask = await _context.TaskCIA.FindAsync(id);
            if (existingTask == null)
            {
                return null; // Return null if the employee doesn't exist
            }

            // Update the employee fields
            existingTask.description = updatedtask.description;
            existingTask.callbackno = updatedtask.callbackno;

            existingTask.comment = updatedtask.comment;
            existingTask.status = updatedtask.status;
            existingTask.Assignedto = updatedtask.Assignedto;
            existingTask.category = updatedtask.category;
            existingTask.Urgencylevel = updatedtask.Urgencylevel;







            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingTask; // Return the updated employee
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.TaskCIA.FindAsync(id);
            if (task == null) return false;

             _context.TaskCIA.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
