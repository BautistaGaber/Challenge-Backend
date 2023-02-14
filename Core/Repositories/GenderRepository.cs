using ChallengeAlkemy.Core.Repositories.Interfaces;
using ChallengeAlkemy.Data;
using ChallengeAlkemy.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAlkemy.Core.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly AplicationDbContext _context;

        public GenderRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Gender>> GetGender()
        {
            return await _context.Genders.ToListAsync();
        }
    }
}
