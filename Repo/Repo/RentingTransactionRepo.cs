using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class RentingTransactionRepo
    {
        private FucarRentingManagementContext _context;
        public RentingTransactionRepo()
        {
            _context = new FucarRentingManagementContext();
        }
        public IEnumerable<RentingTransaction> GetAll() => _context.RentingTransactions.ToList();
        public IEnumerable<RentingTransaction> GetAllWithStatus(byte? rentingStatus)
            => _context.RentingTransactions.Where(c => c.RentingStatus == rentingStatus).ToList();
        public RentingTransaction GetTransactionId(int transactionId) => _context.RentingTransactions.Where(c => c.RentingTransationId == transactionId).FirstOrDefault();
        public IEnumerable<RentingTransaction> GetCustomerId(int customerId) => _context.RentingTransactions.Where(c => c.CustomerId == customerId).ToList();
        public void Add(RentingTransaction transaction)
        {
            _context.Add(transaction);
            _context.SaveChanges();
        }
        public void Delete(RentingTransaction transaction)
        {
            _context.Remove(transaction);
            _context.SaveChanges();
        }
    }
}
