using ShoppingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDal
{
    public class CategoryDataAccess
    {
        ShoppingDbContext _db;
        public CategoryDataAccess(ShoppingDbContext db) => _db = db;

        public List<Category> GetAllCategories()
        {
            var items = _db.Categories.ToList();
            return items;
        }
        public Category GetCategoryById(int id)
        {
            var item = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            return item;
        }
        public void AddNewCategory(Category item)
        {
            _db.Categories.Add(item);
            _db.SaveChanges();
            return;
        }
        public void RemoveCategory(int id)
        {

            var model = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (model != null)
            {
                _db.Categories.Remove(model);
                _db.SaveChanges();
                return;
            }
        }
        public void UpdateCategory(Category category)
        {

            var model = _db.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (model != null)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return;
            }
        }
    }
}
