using ShoppingApp;
using ShoppingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDal
{
    public class ProductDataAccess
    {

        ShoppingDbContext _db;
        public ProductDataAccess(ShoppingDbContext db) => _db = db;

        public List<Product> GetAllProducts()
        {
            var items = _db.Products.ToList();
            return items;
        }
        public Product GetProductById(int id)
        {
            var item = _db.Products.FirstOrDefault(c => c.ProductId == id);
            return item;
        }
        public void AddNewProduct(Product item)
        {
            _db.Products.Add(item);
            _db.SaveChanges();
            return;
        }
        public void UpdateProduct(Product product)
        {

            var model = _db.Products.FirstOrDefault(c => c.ProductId == product.ProductId);
            if (model != null)
            {
                _db.Products.Update(product);
                _db.SaveChanges();
                return;
            }
        }
        public void RemoveProduct(int id)
        {

            var model = _db.Products.FirstOrDefault(c => c.ProductId == id);
            if (model != null)
            {
                _db.Products.Remove(model);
                _db.SaveChanges();
                return;
            }
        }
    }
}
