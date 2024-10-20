namespace ServiceLayer.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CommonModels;

    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();

        Task<Customer?> GetById(int id);

        Task Delete(int id);

        Task Update(Customer customer);
    }
}
