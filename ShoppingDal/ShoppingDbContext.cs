using Microsoft.EntityFrameworkCore;
using ShoppingApp;

namespace ShoppingDal
{
    public class ShoppingDbContext : DbContext
    {
        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public ShoppingDbContext() : base()
        {

        }
        public ShoppingDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetail>().HasKey("OrderId", "ProductId");
        }
    }
}