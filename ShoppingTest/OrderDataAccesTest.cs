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
    public class OrderDataAccessTest
    {
        OrderDataAccess dataAccess;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<ShoppingDbContext> bldr = new DbContextOptionsBuilder<ShoppingDbContext>();
            bldr.UseSqlServer(connectionString: @"server=YASWANTH\SQLEXPRESS;database=shopping;integrated security=true;TrustServerCertificate=true;trusted_connection=true;");
            ShoppingDbContext context = new ShoppingDbContext(bldr.Options);
            dataAccess = new OrderDataAccess(context);
        }

        [Test]
        public void GetAllOrders_Test()
        {
            var expectedCount = 5;

            var orders = dataAccess.GetAllOrders();
            var actualCount = orders.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]
        public void AddProductTest()
        {
            //Arrange 
            var expectedCount = dataAccess.GetAllOrders().Count;
            var actualCount = 0;
            var item = new Order
            {
                //OrderId = "ABC", 
                OrderDate = DateTime.Now,
                OrderTotal = 500,
                ShipmentDate = DateTime.Today.AddDays(3),
                OrderStatus = "Confirmed",
                CustomerId = 3
            };
            //Act 
            dataAccess.AddNewOrder(item);

            actualCount = dataAccess.GetAllOrders().Count;

            //Assert 
            Assert.AreEqual(expectedCount + 1, actualCount);
        }
    }
}
