using Microsoft.EntityFrameworkCore;
using ZDZSTORE.database;
using ZDZSTORE.User.Model;

namespace ZDZSTORE.User
{
    public class UserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserModel?> GetOne(string id)
        {
            UserModel? userModel = await _context.Users.FindAsync(id);

            return userModel;
        }  
        
        public async Task<UserModel?> GetOneByEmail(string email)
        {
            UserModel? userModel = await _context.Users.FirstOrDefaultAsync(user => user.email == email);

            return userModel;
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            IEnumerable<UserModel> users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<UserModel> CreateOne(UserModel user)
        {
            _context.Users.Add(user);
            await this.Update();

            return user;
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOne(UserModel user)
        {
            _context.Remove(user);
            await this.Update();
        }

    }
}
