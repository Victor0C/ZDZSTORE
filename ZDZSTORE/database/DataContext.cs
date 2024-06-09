using Microsoft.EntityFrameworkCore;

namespace ZDZSTORE.database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User.Model.UserModel> Users { get; set; }
    }
}
