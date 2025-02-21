using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Dbcontext;
using Rividco_solar__.Models;
namespace Rividco_solar__.Services
{
    public class Employeeservice:IEmployeeservice
    {
        private readonly AppDbcontext _context;

        public Employeeservice(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Employee> employee, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10)
        {
            var TotalCount = await _context.employees.CountAsync();
            var employees = await _context.employees.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (employees, TotalCount);
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.employees.FindAsync(id);
        }

        public async Task<Employee> AddAsync(Employee employe)
        {
            _context.employees.Add(employe);
            await _context.SaveChangesAsync();
            return employe;
        }
        public async Task<Employee?> UpdateAsync(int id, Employee updatedEmployee)
        {
            // Find the employee in the database
            var existingEmployee = await _context.employees.FindAsync(id);
            if (existingEmployee == null)
            {
                return null; // Return null if the employee doesn't exist
            }

            // Update the employee fields
            existingEmployee.email = updatedEmployee.email;


            existingEmployee.mobileno = updatedEmployee.mobileno;
            existingEmployee.officeno = updatedEmployee.officeno;
           
            existingEmployee.Address = updatedEmployee.Address;
            existingEmployee.FirstName = updatedEmployee.FirstName;
            existingEmployee.LastName = updatedEmployee.LastName;





            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingEmployee; // Return the updated employee
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            if (employee == null) return false;

            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
