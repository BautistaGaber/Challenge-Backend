using ChallengeAlkemy.Core.User;
using ChallengeAlkemy.Data;

namespace ChallengeAlkemy.Core.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AplicationDbContext _context;

        public UserRepository(AplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
            return user;
        }
        public async Task<User> GetUserbyID(int id)
        {
            var result = _context.Users.FirstOrDefault(c => c.Id == id);
             return result;

        }
        public async Task<User> GetUserbyUsername(string username)
        {
           var result = _context.Users.FirstOrDefault(u => u.Username == username);
            return result;
        }
    }
}
