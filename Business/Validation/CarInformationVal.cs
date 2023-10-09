using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class CarInformationVal
    {
        private FucarRentingManagementContext _context;
        public CarInformationVal()
        {
            _context = new FucarRentingManagementContext();
        }
        public bool checkYear(int year)
        {
            if (year < 1885 || year > DateTime.Now.Year)
            {
                return false;
            }
            return true;
        }
        public bool checkManufacturer(string manufacturer)
        {
            if (!string.IsNullOrEmpty(manufacturer))
            {
                if (_context.Manufacturers.Any(c => c.ManufacturerName.Equals(manufacturer, StringComparison.OrdinalIgnoreCase)))
                {
                    return true;
                }
            }
            return false;
        }
        public bool checkSupplier(string supplier)
        {
            if(!string.IsNullOrEmpty(supplier))
            {
                if(_context.Suppliers.Any(c => c.SupplierName.Equals(supplier, StringComparison.OrdinalIgnoreCase)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
