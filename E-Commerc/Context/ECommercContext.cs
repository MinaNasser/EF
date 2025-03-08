

using E_Commerc.Entites;
using Microsoft.EntityFrameworkCore;

namespace E_Commerc.Context
{
    public class ECommercContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<StockHistory> StockHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                  .UseSqlServer("Data source = .; Initial catalog = DB_ECommerc; Integrated security= true; trustservercertificate = true;");
    }
}
