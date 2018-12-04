namespace HTTPServer.ByTheCakeApplication.Data
{
    using HTTPServer.ByTheCakeApplication.Models;
    using Microsoft.EntityFrameworkCore;
    public class ByTheCakeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Proudctus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProudctOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasMany(product => product.Orders)
                .WithOne(order => order.Product)
                .HasForeignKey(po => po.OrderId);
            modelBuilder
                .Entity<Order>()
                .HasMany(order => order.Products)
                .WithOne(product => product.Order)
                .HasForeignKey(po => po.ProductId);
            modelBuilder
                .Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });

            base.OnModelCreating(modelBuilder);

        }
    }
}
