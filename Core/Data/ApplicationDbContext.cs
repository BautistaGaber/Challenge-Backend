using ChallengeAlkemy.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAlkemy.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Gender> Genders { get; set; }

    }
}
