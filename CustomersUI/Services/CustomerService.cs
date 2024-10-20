namespace CustomersUI.Services
{
    using CommonModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Net.Http;
    using System.Text.Json;
    using Microsoft.AspNetCore.Http.HttpResults;

    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public CustomerService(ILogger<CustomerService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("CustomersWebAPI");
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var response = await _httpClient.GetAsync("api/Customer/GetAll");

            var customers = new List<Customer>();

            if (!response.IsSuccessStatusCode)
            {
                // can log issue and/or return error code
                return customers;
            }

            var customerJson = await response.Content.ReadAsStringAsync();

            customers = JsonSerializer.Deserialize<List<Customer>>(
                customerJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            )!;

            return customers.OrderBy(c => c.Id).ToList();
        }

        public async Task<Customer?> GetCustomer(int customerId)
        {
            var response = await _httpClient.GetAsync($"api/Customer/GetById?id={customerId}");

            if (!response.IsSuccessStatusCode)
            {
                // can log issue and/or return error code
                return null;
            }

            var customerJson = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Customer>(
                customerJson,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public async Task<IActionResult> SaveCustomer(Customer customer)
        {
            var response =  await _httpClient.PostAsJsonAsync("api/Customer/Save", customer);

            if (response.IsSuccessStatusCode)
            {
                // can log issue and/or return error code
                return new OkResult();
            }

            _logger.LogError("Error Saving Customer");
            return new BadRequestResult();
        }

        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var response = await _httpClient.DeleteAsync($"api/Customer/Delete?id={customerId}");

            if (response.IsSuccessStatusCode)
            {
                // can log issue and/or return error code
                return new OkResult();
            }

            _logger.LogError("Error Deleting Customer");
            return new BadRequestResult();
        }
    }
}
