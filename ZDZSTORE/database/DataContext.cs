using Microsoft.EntityFrameworkCore;
using ZDZSTORE.Product.Model;
using ZDZSTORE.Sale.Model;

namespace ZDZSTORE.database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleModel>()
                .HasOne(sale => sale.user)
                .WithMany(user => user.sales)
                .HasForeignKey(sale => sale.userID);

            modelBuilder.Entity<SaleModel>()
                .HasMany(sale => sale.items)
                .WithOne(item => item.sale)
                .HasForeignKey(item => item.saleID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductModel>()
                .HasMany(product => product.items)
                .WithOne(item => item.product)
                .HasForeignKey(item => item.productID)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User.Model.UserModel> Users { get; set; }
        public DbSet<Product.Model.ProductModel> Products { get; set; }
        public DbSet<SaleModel> Sales { get; set; }
        public DbSet<ItemModel> Items { get; set; }
    }
}