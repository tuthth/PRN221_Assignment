using CarRental.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class CustomerRepo
    {
        private FucarRentingManagementContext _context;
        public CustomerRepo()
        {
            _context = new FucarRentingManagementContext();
        }
        public IEnumerable<Customer> GetAll() => _context.Customers.ToList();
        public Customer GetUserWithId(int id) => _context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
        public Customer GetUser(string username, string password)
        {
            Customer customer = new Customer();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                customer = null;
            }
            else
            {
                customer = _context.Customers.Where(c => c.Email.Equals(username)
                && c.Password.Equals(password)).FirstOrDefault();
            }
            return customer;
        }
        public IEnumerable<Customer> GetListWithFilter(string keyword)
        {
            keyword = keyword.ToLower();
            if (!string.IsNullOrEmpty(keyword))
            {
                if (DateOnly.TryParse(keyword, out DateOnly date))
                {
                    return _context.Customers.Where(c => c.CustomerBirthday.Equals(date)).ToList();
                }
                else
                {
                    return _context.Customers.Where(c => c.CustomerName.ToLower().Contains(keyword)
                        || c.Telephone.ToLower().Contains(keyword) || c.Email.ToLower().Contains(keyword)).ToList();
                }
            }
            return null;
        }
        public void Add(Customer customer)
        {
            if (customer != null)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
        }
        public void Update(Customer customer)
        {
            if (customer != null)
            {
                _context.Update(customer);
                _context.SaveChanges();
            }
        }
        public void Delete(Customer customer)
        {
            if (customer != null)
            {
                _context.Remove(customer);
                _context.SaveChanges();
            }
        }
        public Customer GetAdminAccount() => _context.GetAdminAccount();
    }
}
