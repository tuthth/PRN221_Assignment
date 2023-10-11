using CarRental.Models;
using DAL.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Assignment_Razor.Pages
{
    public class CreateRentingModel : PageModel
    {
        public CarInformationRepo CarInformationRepo;
        public RentingDetailRepo RentingDetailRepo;
        public RentingTransactionRepo RentingTransactionRepo;
        public CustomerRepo CustomerRepo;
        public List<RentingDetail> rentingDetails;

        public IEnumerable<CarInformation> Cars;
        public IEnumerable<Customer> Customers;

        [BindProperty]
        public int CarId { get; set; }

        [BindProperty]
        public int CustomerId { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        [BindProperty]
        public decimal Price { get; set; }

        public CreateRentingModel()
        {
            CarInformationRepo = new CarInformationRepo();
            RentingTransactionRepo = new RentingTransactionRepo();
            RentingDetailRepo = new RentingDetailRepo();
            CustomerRepo = new CustomerRepo();
            rentingDetails = new List<RentingDetail>();
        }
        public void OnGet()
        {
            Cars = CarInformationRepo.GetCarListInformation();
            Customers = CustomerRepo.GetAll();
        }
        public IActionResult OnPost()
        {
            var detail = new RentingDetail {
                CarId = CarId, StartDate = StartDate, EndDate = EndDate, Price = Price
            };
            rentingDetails.Add(detail);
            int numberOfDays = (int)(detail.EndDate - detail.StartDate).TotalDays;
            decimal? totalPrice = detail.Price * numberOfDays;

            RentingTransaction transaction = new RentingTransaction
            {
                RentingTransationId = RentingTransactionRepo.GetAll().Count(),
                RentingDate = DateTime.Now.Date,
                CustomerId = CustomerId,
                TotalPrice = totalPrice,
                RentingDetails = rentingDetails,
                RentingStatus = 0
            };

            RentingTransactionRepo.Add(transaction);
            RentingDetailRepo.Add(detail);

            return Page();

        }
    }
}
