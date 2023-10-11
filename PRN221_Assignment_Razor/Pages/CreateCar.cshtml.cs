using CarRental.Models;
using DAL.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Assignment_Razor.Pages
{
    public class CreateCarModel : PageModel
    {
        private readonly CarInformationRepo _carRepo;

        public CreateCarModel()
        {
            _carRepo = new CarInformationRepo();
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public int NumberOfDoors { get; set; }

        [BindProperty]
        public int SeatingCapacity { get; set; }

        [BindProperty]
        public string FuelType { get; set; }

        [BindProperty]
        public int Year { get; set; }

        [BindProperty]
        public int ManufacturerId { get; set; }

        [BindProperty]
        public int SupplierId { get; set; }

        [BindProperty]
        public byte Status { get; set; }

        [BindProperty]
        public decimal RentPerDay { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {

            try
            {
                CarInformation car = new CarInformation
                {
                    CarName = Name,
                    CarDescription = Description,
                    NumberOfDoors = NumberOfDoors,
                    SeatingCapacity = SeatingCapacity,
                    FuelType = FuelType,
                    Year = Year,
                    ManufacturerId = ManufacturerId,
                    SupplierId = SupplierId,
                    CarStatus = Status,
                    CarRentingPricePerDay = RentPerDay
                };
            }
            catch (Exception e)
            {

                throw;
            }

            return Page();
        }

    }
}
