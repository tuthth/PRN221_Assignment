using CarRental.Models;
using DAL.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Assignment_Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private CustomerRepo _cusRepo;
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _cusRepo = new CustomerRepo();
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost() //login
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("", "No username or/and password, try again");
                return Page();
            }
            else
            {              
                Customer admin = _cusRepo.GetAdminAccount();
                Console.WriteLine(Directory.GetCurrentDirectory());

                if (Email.Equals(admin.Email) && Password.Equals(admin.Password))
                {
                    TempData["AdminMessage"] = "Welcome back Admin";
                    return RedirectToPage("/Admin"); 
                }
                else
                {
                    Customer customer = _cusRepo.GetUser(Email, Password);
                    if (customer == null)
                    {
                        ModelState.AddModelError("", "Incorrect password");
                        return Page();
                    }
                    else
                    {
                        if (customer.Email.Equals(admin.Email))
                        {
                            ModelState.AddModelError("", "Illegal account");
                            return Page();
                        }
                        else
                        {
                            TempData["CustomerMessage"] = string.Format("Welcome back, {0}", customer.CustomerName);
                            TempData["Customer"] = customer;
                            return RedirectToPage("/Customer", new { customer = customer });
                        }
                    }
                }
            }
        }
    }
}