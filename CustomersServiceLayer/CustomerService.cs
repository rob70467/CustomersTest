namespace ServiceLayer
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CommonModels;
    using Interfaces;
    using Microsoft.Extensions.Options;
    using RepositoryLayer.Interfaces;

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer?>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer?> GetById(int id)
        {
            return await _customerRepository.GetById(id);
        }

        public async Task Delete(int id)
        {
            await _customerRepository.Delete(id);
        }

        public async Task Update(Customer customer)
        {
            // validate customer
            ValidateCustomer(customer);
            
            await _customerRepository.Update(customer);
        }

        private void ValidateCustomer(Customer customer)
        {
            // required fields, field length, name and/or reference uniqueness if not db enforced

            if (customer == null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                throw new ArgumentException("Name is required");
            }

            if (string.IsNullOrWhiteSpace(customer.Reference))
            {
                throw new ArgumentException("Reference is required");
            }
        }

    }
}
