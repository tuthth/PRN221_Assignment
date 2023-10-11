using CarRental.Models;
using DAL.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Packaging.Signing;
using NuGet.Protocol.Plugins;

namespace PRN221_Assignment_Razor.Pages
{
    public class CarInfoManageModel : PageModel
    {
        private readonly CarInformationRepo _repo;
        private readonly RentingDetailRepo rentingDetailRepo;

        public CarInfoManageModel()
        {
            _repo = new CarInformationRepo();
            rentingDetailRepo = new RentingDetailRepo();
        }

        [BindProperty]
        public IEnumerable<CarInformation> CarsList { get; set; }

        [BindProperty]
        public int SelectedCarId { get; set; }
        [BindProperty]
        public int CarId { get; set; }
        [BindProperty]
        public string CarName { get; set; } = null!;
        [BindProperty]
        public string? CarDescription { get; set; }
        [BindProperty]
        public int? NumberOfDoors { get; set; }
        [BindProperty]
        public int? SeatingCapacity { get; set; }
        [BindProperty]
        public string? FuelType { get; set; }
        [BindProperty]
        public int? Year { get; set; }
        [BindProperty]
        public int ManufacturerId { get; set; }
        [BindProperty]
        public int SupplierId { get; set; }
        [BindProperty]
        public byte? CarStatus { get; set; }
        [BindProperty]
        public decimal? CarRentingPricePerDay { get; set; }

        public void OnGet()
        {
            CarsList = _repo.GetCarListInformation();
        }

        public IActionResult OnPost()
        {
            var car = _repo.GetCarId(SelectedCarId);

            car.CarName = CarName;
            car.CarDescription = CarDescription;
            car.NumberOfDoors = NumberOfDoors;
            car.SeatingCapacity = SeatingCapacity;
            car.FuelType = FuelType;
            car.Year = Year;
            car.ManufacturerId = ManufacturerId;
            car.SupplierId = SupplierId;
            car.CarStatus = CarStatus;
            car.CarRentingPricePerDay = CarRentingPricePerDay;


            _repo.Update(car);

            return RedirectToPage();
        }

        public IActionResult OnPostDelete()
        {
            var car = _repo.GetCarId(SelectedCarId);

            if (rentingDetailRepo.CarIdExist(SelectedCarId) == true)
            {
                car.CarStatus = 1;
                _repo.Update(car);

            }
            else
            {
                _repo.Delete(car);
            }

            return RedirectToPage();
        }

    }
}
