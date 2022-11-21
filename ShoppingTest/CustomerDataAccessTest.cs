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
    public class CustomerDataAccessTest
    {
        CustomerDataAccess dataAccess;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<ShoppingDbContext> bldr = new DbContextOptionsBuilder<ShoppingDbContext>();
            bldr.UseSqlServer(connectionString: @"server=YASWANTH\SQLEXPRESS;database=shopping;integrated security=true;TrustServerCertificate=true;trusted_connection=true;");
            ShoppingDbContext context = new ShoppingDbContext(bldr.Options);
            dataAccess = new CustomerDataAccess(context);
        }

        [Test]
        public void GetAllCustomers_Test()
        {
            var expectedCount = 3;

            var customers = dataAccess.GetAllCustomers();
            var actualCount = customers.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]
        public void AddCustomerTest()
        {
            //Arrange 
            var expectedCount = dataAccess.GetAllCustomers().Count;
            var actualCount = 0;
            var item = new Customer
            {
                //ProductId = "ABC",
                CustomerName = "Hemanth",
                CustomerEmail = "hemanth2@gmail.com",
                CustomerPassword = "hemanth",
                CustomerAddress = "D.no:32",
                CustomerCity = "Hyderabad",
                CustomerPostalCode = 600012
            };
            //Act 
            dataAccess.AddNewCustomer(item);

            actualCount = dataAccess.GetAllCustomers().Count;

            //Assert 
            Assert.AreEqual(expectedCount + 1, actualCount);
        }
    }
}
