using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Models;

namespace ChallengeAlkemy.Core.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMovies();       
        Task<Movie> GetMovieById(int id);
        Task<List<Movie>> SerchMovie(string title, int? genderid);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(int id);
        Task SaveChanges();
        Task<Movie> CreateMovie(Movie movie);
    }
}
