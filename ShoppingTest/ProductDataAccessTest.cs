using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ShoppingApp;
using ShoppingDal;

namespace ProductTest
{
    public class ProductDataAccessTest
    {
        ProductDataAccess dataAccess;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<ShoppingDbContext> bldr = new DbContextOptionsBuilder<ShoppingDbContext>();
            bldr.UseSqlServer(connectionString: @"server=YASWANTH\SQLEXPRESS;database=shopping;integrated security=true;TrustServerCertificate=true;trusted_connection=true;");
            ShoppingDbContext context = new ShoppingDbContext(bldr.Options);
            dataAccess = new ProductDataAccess(context);
        }

        [Test]
        public void GetAllProducts_Test()
        {
            var expectedCount = 4;

            var products = dataAccess.GetAllProducts();
            var actualCount = products.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]
        public void AddProductTest()
        {
            //Arrange 
            var expectedCount = dataAccess.GetAllProducts().Count;
            var actualCount = 0;
            var item = new Product
            {
                //ProductId = "ABC",
                ProductName = "Mouse",
                ProductPrice = 500,
                ProductQty = 10,
                SellerId = 101,
                CategoryId = 1001,
            };
            //Act 
            dataAccess.AddNewProduct(item);

            actualCount = dataAccess.GetAllProducts().Count;

            //Assert 
            Assert.AreEqual(expectedCount + 1, actualCount);
        }
    }
}