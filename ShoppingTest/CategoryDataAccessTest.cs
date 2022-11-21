using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ShoppingApp;
using ShoppingDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTest
{
    public class CategoryDataAccessTest
    {
        CategoryDataAccess dataAccess;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<ShoppingDbContext> bldr = new DbContextOptionsBuilder<ShoppingDbContext>();
            bldr.UseSqlServer(connectionString: @"server=YASWANTH\SQLEXPRESS;database=shopping;integrated security=true;TrustServerCertificate=true;trusted_connection=true;");
            ShoppingDbContext context = new ShoppingDbContext(bldr.Options);
            dataAccess = new CategoryDataAccess(context);
        }

        [Test]
        public void GetAllCategories_Test()
        {
            var expectedCount = 3;

            var categories = dataAccess.GetAllCategories();
            var actualCount = categories.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]
        public void AddCategoryTest()
        {
            //Arrange 
            var expectedCount = dataAccess.GetAllCategories().Count;
            var actualCount = 0;
            var item = new Category
            {
                //ProductId = "ABC",
                CategoryName = "Groceries"
            };
            //Act 
            dataAccess.AddNewCategory(item);

            actualCount = dataAccess.GetAllCategories().Count;

            //Assert 
            Assert.AreEqual(expectedCount + 1, actualCount);
        }
    }
}
