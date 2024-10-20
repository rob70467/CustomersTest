namespace RepositoryLayer.Interfaces
{
    using CommonModels;

    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer?>> GetAll();

        Task<Customer?> GetById(int id);

        Task Delete(int id);

        Task Update(Customer customer);
    }
}
