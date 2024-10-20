namespace DataAccessLayer.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerData
    {
        Task<List<CustomerEntity>> GetAllCustomers();

        Task<CustomerEntity?> GetCustomerById(int id);

        Task<CustomerEntity> UpdateCustomer(CustomerEntity customer);

        Task DeleteCustomerById(int id);
    }
}
