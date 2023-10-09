using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class SupplierRepo
    {
        private FucarRentingManagementContext _context;
        public SupplierRepo()
        {
            _context = new FucarRentingManagementContext();
        }
        public IEnumerable<Supplier> GetAll() => _context.Suppliers.ToList();
        public IEnumerable<Supplier> GetListWithKeyword(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _context.Suppliers.Where(c => c.SupplierName.Contains(keyword) || c.SupplierAddress.Contains(keyword));
            }
            return null;
        } 
        public void Update(Supplier supplier)
        {
            _context.Update(supplier);
            _context.SaveChanges();
        }
        public void Delete(Supplier supplier)
        {
            _context.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
