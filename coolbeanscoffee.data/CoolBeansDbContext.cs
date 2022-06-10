using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using coolbeanscoffee.data.Models;

namespace coolbeanscoffee.data {
    public class CoolBeansDbContext : IdentityDbContext {
        public CoolBeansDbContext() { }

        public CoolBeansDbContext(DbContextOptions<CoolBeansDbContext> options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductInventory> ProductInventories { get; set; }
        public virtual DbSet<ProductInventorySnapshot> ProductInventorySnapshots { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }
        public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; }
    }
}
