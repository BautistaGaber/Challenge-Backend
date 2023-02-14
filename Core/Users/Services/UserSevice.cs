using ChallengeAlkemy.Core.User;
using ChallengeAlkemy.Core.Users.Repositories;
using ChallengeAlkemy.Core.Users.Services.Interfaces;
using ChallengeAlkemy.Helper;
using System.Security.Cryptography;
using System.Text;

namespace ChallengeAlkemy.Core.Users.Services
{
    public class UserSevice : IUserService
    {
        private readonly IUserRepository _repository;

        public UserSevice(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> CreateUser(UserDTO userDTO)
        {
            User user = ApiHelper.CreateUserToEntity(userDTO);
            CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Username = userDTO.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            var result = await _repository.CreateUser(user);
            return result;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _repository.GetUserbyID(id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _repository.GetUserbyUsername(username);
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
