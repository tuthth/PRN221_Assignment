using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class RentingDetailRepo
    {
        private FucarRentingManagementContext _context;
        public RentingDetailRepo()
        {
            _context = new FucarRentingManagementContext();
        }
        public IEnumerable<RentingDetail> GetAll() => _context.RentingDetails.ToList();
        public IEnumerable<RentingDetail> GetListRTId(int id) => _context.RentingDetails.Where(c => c.RentingTransactionId == id).ToList();
        public IEnumerable<RentingDetail> GetListCarId(int id) => _context.RentingDetails.Where(c => c.CarId == id).ToList();
        public bool CarIdExist(int id) => _context.RentingDetails.Any(c => c.CarId == id);
        public IEnumerable<RentingDetail> GetDateRange(DateTime? start, DateTime? end)
        {
            if (!start.HasValue)
            {
                return null;
            }
            else
            {
                if (end.HasValue)
                {
                    return _context.RentingDetails.Where(c => c.StartDate >= start && c.EndDate <= end).ToList();
                }
                else return _context.RentingDetails.Where(c => c.StartDate >= start).ToList();
            }
        }

        public IEnumerable<RentingDetail> GetCustomerId()
        {
            throw new NotImplementedException();
        }
        public void Add(RentingDetail rentingDetail)
        {
            _context.Add(rentingDetail);
            _context.SaveChanges();
        }
        public void Remove(RentingDetail rentingDetail)
        {
            _context.Remove(rentingDetail);
            _context.SaveChanges();
        }
       
    }
}
