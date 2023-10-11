using CarRental.Models;
using DAL.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Assignment_Razor.Pages
{
    public class CreateCustomerModel : PageModel
    {
        private readonly CustomerRepo _customerRepo;

        public CreateCustomerModel()
        {
            _customerRepo = new CustomerRepo();
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public DateTime Birthday { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var customer = new Customer()
            {
                CustomerName = Name,
                Telephone = Phone,
                Email = Email,
                CustomerBirthday = Birthday,
                Password = Password,
                CustomerStatus = 0
            };

            _customerRepo.Add(customer);

            return Page();
        }

    }
}
