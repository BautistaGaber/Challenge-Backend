using ChallengeAlkemy.Core.Repositories.Interfaces;
using ChallengeAlkemy.Data;
using ChallengeAlkemy.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAlkemy.Core.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AplicationDbContext _context;

        public CharacterRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Character> CreateCharacter(Character character)
        {
            await _context.Characters.AddAsync(character);
            _context.SaveChanges(); 
            return character;
        }

        public async Task DeleteCharacter(int id)
        {
            var result = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            _context.Characters.Remove(result);
            await SaveChanges();
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var result = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<List<Character>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCharacter(Character character)
        {
            _context.Characters.Update(character);
        }
    }
}
