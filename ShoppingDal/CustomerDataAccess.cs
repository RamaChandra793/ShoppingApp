using ShoppingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDal
{
    public class CustomerDataAccess
    {
        ShoppingDbContext _db;
        public CustomerDataAccess(ShoppingDbContext db) => _db = db;

        public List<Customer> GetAllCustomers()
        {
            var items = _db.Customers.ToList();
            return items;
        }
        public Customer GetCustomerById(int id)
        {
            var item = _db.Customers.FirstOrDefault(c => c.CustomerId == id);
            return item;
        }
        public void AddNewCustomer(Customer item)
        {
            _db.Customers.Add(item);
            _db.SaveChanges();
            return;
        }
        public void UpdateCustomer(Customer customer)
        {

            var model = _db.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (model != null)
            {
                _db.Customers.Update(customer);
                _db.SaveChanges();
                return;
            }
        }
    }
}
