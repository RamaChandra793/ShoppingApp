using ShoppingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDal
{
    public class OrderDetailDataAccess
    {
        ShoppingDbContext _db;
        public OrderDetailDataAccess(ShoppingDbContext db) => _db = db;

        public List<OrderDetail> GetAllOrderDetails()
        {
            var items = _db.OrderDetails.ToList();
            return items;
        }
        public OrderDetail GetOrderDetailById(int id)
        {
            var item = _db.OrderDetails.FirstOrDefault(c => c.OrderId == id);
            return item;
        }
    }
}
