namespace CustomersUI.Services
{
    using CommonModels;
    using Microsoft.AspNetCore.Mvc;

    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();

        Task<Customer?> GetCustomer(int customerId);

        Task<IActionResult> SaveCustomer(Customer customer);

        Task<IActionResult> DeleteCustomer(int customerId);
    }
}
