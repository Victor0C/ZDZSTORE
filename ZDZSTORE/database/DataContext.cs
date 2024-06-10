using Microsoft.EntityFrameworkCore;
using ZDZSTORE.Product.Model;
using ZDZSTORE.User.Model;

namespace ZDZSTORE.database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User.Model.UserModel> Users { get; set; }
        public DbSet<Product.Model.ProductModel> Products { get; set; }
    }
}