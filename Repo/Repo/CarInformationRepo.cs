using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class CarInformationRepo
    {
        private FucarRentingManagementContext _context;
        public CarInformationRepo()
        {
            _context = new FucarRentingManagementContext();
        }
        public CarInformation GetCarId(int id) => _context.CarInformations.Where(c => c.CarId == id).FirstOrDefault();
        public IEnumerable<CarInformation> GetCarListInformation() => _context.CarInformations.ToList();
        public IEnumerable<CarInformation> GetCarInformationWithName(string name) =>
            _context.CarInformations.Where(c => c.CarName.Contains(name)).ToList();
        public void Update(CarInformation carInformation)
        {
            _context.Update(carInformation);
            _context.SaveChanges();
        }
        public void Delete(CarInformation carInformation)
        {
            _context.Remove(carInformation);
            _context.SaveChanges();
        }
        public void Add(CarInformation carInformation)
        {
            _context.Add(carInformation);
            _context.SaveChanges();
        }
    }
}
