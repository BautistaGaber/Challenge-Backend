using ChallengeAlkemy.DTO.DTOs;
using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Models;

namespace ChallengeAlkemy.Core.Services.Interfaces
{
    public interface ICharacterServices
    {
        Task<List<ViewCharacterDTO>> GetCharacters();
        Task<List<FullCharacterDTO>> GetCharactersWithAllProperties();
        Task<Character> GetCharacterById(int id);
        Task <Character> CreateCharacter(CreateCharacterDTO createCharacterDto);
        Task CharaterMovie(int id, List<int> characterid);
        Task UpdateCharacter(UpdateCharacterDTO updateCharacterDto, int id);
        Task DeleteCharacter(int id);
    }
}
