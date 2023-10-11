using CarRental.Models;
using DAL.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PRN221_Assignment_Razor.Pages
{
    public class CustomerManagerModel : PageModel
    {
        private readonly CustomerRepo _customer;

        public CustomerManagerModel()
        {
            _customer = new CustomerRepo();
        }

        public IEnumerable<Customer> Customers { get; private set; }

        [BindProperty]
        public int SelectedCustomerId { get; set; }

        [BindProperty]
        public string CustomerName { get; set; }

        [BindProperty]
        public string Telephone { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public DateTime CustomerBirthday { get; set; }

        [BindProperty]
        public byte CustomerStatus { get; set; }

        public SelectList CustomerIds { get; private set; }

        public void OnGet()
        {
            Customers = _customer.GetAll();
            CustomerIds = new SelectList(Customers.Select(c => c.CustomerId));
        }

        public IActionResult OnPost()
        {
            if (SelectedCustomerId == 0)
            {
                TempData["Message"] = "Please select a customer.";
                return RedirectToPage();
            }

            Customer existingCustomer = _customer.GetUserWithId(SelectedCustomerId);

            if (existingCustomer != null)
            {
                existingCustomer.CustomerName = CustomerName;
                existingCustomer.Telephone = Telephone;
                existingCustomer.Email = Email;
                existingCustomer.CustomerBirthday = CustomerBirthday;
                existingCustomer.CustomerStatus = CustomerStatus;

                _customer.Update(existingCustomer);

                TempData["Message"] = "Update success";
                return RedirectToPage();
            }
            else
            {
                TempData["Message"] = "Customer not found in the database.";
                return RedirectToPage();
            }
        }

        public IActionResult OnPostCreate()
        {
            return RedirectToPage("/CreateCustomer");
        }

        public IActionResult OnPostDelete()
        {
            if (SelectedCustomerId == 0)
            {
                TempData["Message"] = "Please select a customer first.";
                return RedirectToPage();
            }

            Customer customer = _customer.GetUserWithId(SelectedCustomerId);

            if (customer != null)
            {
                customer.CustomerStatus = 1;
                TempData["Message"] = "Change status success";
                return RedirectToPage();
            }
            else
            {
                TempData["Message"] = "Customer not found in the database.";
                return RedirectToPage();
            }
        }
    }
}
