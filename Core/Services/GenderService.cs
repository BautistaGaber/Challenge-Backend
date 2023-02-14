using ChallengeAlkemy.Core.Repositories.Interfaces;
using ChallengeAlkemy.Core.Services.Interfaces;
using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Models;

namespace ChallengeAlkemy.Core.Services
{
    public class GenderService : IGenderService
    {

        private readonly IGenderRepository _repository;

        public GenderService(IGenderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Gender>> GetGender()
        {
            return await _repository.GetGender();
        }
    }
}
