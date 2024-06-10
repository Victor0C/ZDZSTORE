using Microsoft.EntityFrameworkCore;
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
        }

        public DbSet<User.Model.UserModel> Users { get; set; }
        public DbSet<Product.Model.ProductModel> Products { get; set; }
        public DbSet<SaleModel> Sales { get; set; }
    }
}