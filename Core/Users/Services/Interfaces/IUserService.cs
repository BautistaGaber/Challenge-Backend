using ChallengeAlkemy.Core.User;

namespace ChallengeAlkemy.Core.Users.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);

        Task<User> GetUserByUsername(string username);

        Task<User> CreateUser(UserDTO userDTO);

        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
