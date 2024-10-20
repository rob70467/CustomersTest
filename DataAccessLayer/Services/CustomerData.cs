namespace DataAccessLayer.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using DataAccessLayer;
    using Interfaces;

    public class CustomerData: ICustomerData
    {
        private readonly CustomerDBContext _context;

        public CustomerData(CustomerDBContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerEntity>> GetAllCustomers()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<CustomerEntity?> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<CustomerEntity> UpdateCustomer(CustomerEntity customer)
        {
            var existingCustomer = await GetCustomerById(customer.Id);

            if (existingCustomer == null)
            {
                // Add new customer
                _context.Customers.Add(customer);
            }
            else
            {
                // Update existing customer
                existingCustomer.Name = customer.Name;
                existingCustomer.Reference = customer.Reference;

                _context.Customers.Update(existingCustomer);  
            }
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task DeleteCustomerById(int id)
        {
            var entity = await GetCustomerById(id);

            if (entity == null)
            {
                return;
            }

            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
