using CarRental.Models;
using DAL.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Assignment_Razor.Pages
{
    public class RentingManageModel : PageModel
    {
        public RentingDetailRepo RentingDetailRepo;
        public RentingTransactionRepo RentingTransactionRepo;

        public RentingManageModel()
        {
            RentingTransactionRepo = new RentingTransactionRepo();
            RentingDetailRepo = new RentingDetailRepo();
        }

        public IEnumerable<RentingTransaction> Transactions { get; set; }

        public IEnumerable<RentingDetail> Details { get; set; }

        public void OnGet()
        {
            Transactions = RentingTransactionRepo.GetAll();
            Details = RentingDetailRepo.GetAll();
        }

        public IActionResult OnPostDelete()
        {
            // Delete logic

            return RedirectToPage();
        }
    }
}
