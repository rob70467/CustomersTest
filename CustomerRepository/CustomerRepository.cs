namespace RepositoryLayer
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CommonModels;
    using Interfaces;
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Models;

    /// <summary>
    /// Responsible for Data access, also mapping any Data models to the Common models
    /// </summary>
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public readonly ICustomerData _customerData;

        public CustomerRepository(ICustomerData customerData)
        {
            _customerData = customerData;
        }

        public async Task<IEnumerable<Customer?>> GetAll()
        {
            var results = await _customerData.GetAllCustomers();
            return results.Select(c => Mapper.ToCommon(c));
        }

        public async Task<Customer?> GetById(int id)
        {
            var result = await _customerData.GetCustomerById(id);
            return Mapper.ToCommon(result);
        }

        public async Task Delete(int id)
        {
            await _customerData.DeleteCustomerById(id);
        }

        public async Task Update(Customer? customer)
        {
            await _customerData.UpdateCustomer(Mapper.ToDataLayer(customer)!);
        }
    }
}
