namespace CustomersUI.Pages.Customers
{
    using System.Text.Json;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using CommonModels;
    using Services;


    public class CustomerListModel : PageModel
    {
        private readonly ILogger<CustomerListModel> _logger;
        private readonly ICustomerService _customerService;

        public CustomerListModel(ILogger<CustomerListModel> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [BindProperty] public IList<Customer> Customers { get; set; } = new List<Customer>();

        public async Task OnGetAsync()
        {
            Customers = await _customerService.GetCustomers();
        }

        public async Task<IActionResult> OnGetCustomerDetailsAsync(int id)
        {
            if (id == 0)
            {
                // Return an empty customer for adding new customers
                return new JsonResult(new Customer());
            }

            var customer = await _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            return new JsonResult(customer);
        }

        public async Task<IActionResult> OnPostSaveCustomerAsync(Customer customer)
        {
            return await _customerService.SaveCustomer(customer);
        }


        public async Task<IActionResult> OnPostDeleteCustomerAsync(int id)
        {
            return await _customerService.DeleteCustomer(id);
        }
    }
}
