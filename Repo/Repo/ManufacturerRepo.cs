using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ManufacturerRepo
    {
        private FucarRentingManagementContext _context;
        public ManufacturerRepo()
        {
            _context = new FucarRentingManagementContext();
        }
        public IEnumerable<Manufacturer> GetAll() => _context.Manufacturers.ToList();
        public IEnumerable<Manufacturer> GetListWithFilter(string keyword)
        {
            keyword = keyword.ToLower();
            if(!string.IsNullOrEmpty(keyword))
            {
                return _context.Manufacturers.Where(c => c.ManufacturerName.ToLower().Contains(keyword)
                    || c.ManufacturerCountry.ToLower().Contains(keyword)).ToList();
            }
            return null;
        }
    }
}
