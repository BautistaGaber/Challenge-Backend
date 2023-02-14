using ChallengeAlkemy.Models;

namespace ChallengeAlkemy.Core.Repositories.Interfaces
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetGender();
    }
}
