using ShoppingApp;
using ShoppingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDal
{
    public class OrderDataAccess
    {
        ShoppingDbContext _db;
        public OrderDataAccess(ShoppingDbContext db) => _db = db;

        public List<Order> GetAllOrders()
        {
            var items = _db.Orders.ToList();
            return items;
        }
        public Order GetOrderById(int id)
        {
            var item = _db.Orders.FirstOrDefault(c => c.OrderId == id);
            return item;
        }
        public void AddNewOrder(Order item)
        {
            _db.Orders.Add(item);
            _db.SaveChanges();
            return;
        }
        public void CancelOrder(int id)
        {

            var model = _db.Orders.FirstOrDefault(c => c.OrderId == id);
            if (model != null)
            {
                _db.Orders.Remove(model);
                _db.SaveChanges();
                return;
            }
        }
    }
}
