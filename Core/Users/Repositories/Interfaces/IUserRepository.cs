using ChallengeAlkemy.Core.User;

namespace ChallengeAlkemy.Core.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserbyID(int id);
        Task<User> GetUserbyUsername(string username);
        Task<User> CreateUser(User user); 
    }
}
