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

        public async Task<(IEnumerable<TaskCIA> tasks, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10)
        {
            var TotalCount = await _context.TaskCIA.CountAsync();
            var tasks = await _context.TaskCIA.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (tasks, TotalCount);
        }

        public async Task<TaskCIA> GetByIdAsync(int id)
        {
            return await _context.TaskCIA.FindAsync(id);
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
