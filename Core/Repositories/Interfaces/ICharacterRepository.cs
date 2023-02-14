using ChallengeAlkemy.Models;

namespace ChallengeAlkemy.Core.Repositories.Interfaces
{
    public interface ICharacterRepository
    {
        Task<List<Character>> GetCharacters();       
        Task<Character> GetCharacterById(int id);
        Task <Character>CreateCharacter(Character character);
        Task UpdateCharacter(Character character);
        Task DeleteCharacter(int id);
        Task SaveChanges();
    }
}
