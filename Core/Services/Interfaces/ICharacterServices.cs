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
        Task <Character> CreateCharacter(CreateCharacterDTO createcharacterdto);
        Task CharaterMovie(int id, List<int> characterid);
        Task UpdateCharacter(Character character);
        Task DeleteCharacter(int id);
    }
}
