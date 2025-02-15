using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Dbcontext;
using Rividco_solar__.Models;

namespace Rividco_solar__.Services
{
    public class CustomerServices:ICustomerServices
    {
        private readonly AppDbcontext _context;

        public CustomerServices(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Customer> customers, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10)
        {
            var TotalCount = await _context.customers.CountAsync();
            var customers = await _context.customers.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (customers, TotalCount);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.customers.FindAsync(id);
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer?> UpdateAsync(int id, Customer updatedCustomer)
        {
            // Find the employee in the database
            var existingCustomer = await _context.customers.FindAsync(id);
            if (existingCustomer == null)
            {
                return null; // Return null if the employee doesn't exist
            }

            // Update the employee fields
            existingCustomer.email = updatedCustomer.email;
            existingCustomer.category = updatedCustomer.category;
           
            existingCustomer.mobileno = updatedCustomer.mobileno;
            existingCustomer.officeno = updatedCustomer.officeno;
            existingCustomer.comment = updatedCustomer.comment;
            existingCustomer.Address   = updatedCustomer.Address;
            existingCustomer.FirstName = updatedCustomer.FirstName;
            existingCustomer.LastName = updatedCustomer.LastName;
          




            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingCustomer; // Return the updated employee
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.customers.FindAsync(id);
            if (customer == null) return false;

            _context.customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
      

    }
}
