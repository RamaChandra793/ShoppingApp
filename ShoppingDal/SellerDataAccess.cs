using ShoppingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDal
{
    public class SellerDataAccess
    {

        ShoppingDbContext _db;
        public SellerDataAccess(ShoppingDbContext db) => _db = db;

        public List<Seller> GetAllSellers()
        {
            var items = _db.Sellers.ToList();
            return items;
        }
        public Seller GetSellerById(int id)
        {
            var item = _db.Sellers.FirstOrDefault(c => c.SellerId == id);
            return item;
        }
        public void AddNewSeller(Seller item)
        {
            _db.Sellers.Add(item);
            _db.SaveChanges();
            return;
        }
        public void UpdateSeller(Seller seller)
        {

            var model = _db.Sellers.FirstOrDefault(c => c.SellerId == seller.SellerId);
            if (model != null)
            {
                _db.Sellers.Update(model);
                _db.SaveChanges();
                return;
            }
        }

    }
}
