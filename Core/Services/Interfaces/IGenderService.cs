using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Models;

namespace ChallengeAlkemy.Core.Services.Interfaces
{
    public interface IGenderService
    {
        Task<List<Gender>> GetGender();
    }
}
