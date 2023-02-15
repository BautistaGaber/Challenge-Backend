using ChallengeAlkemy.Core.Repositories.Interfaces;
using ChallengeAlkemy.Core.Services.Interfaces;
using ChallengeAlkemy.DTO.DTOs;
using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Helper;
using ChallengeAlkemy.Models;

namespace ChallengeAlkemy.Core.Services
{
    public class MovieService : IMovieService
    {

        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<Movie> CreateMovie(CreateMovieDTO createmoviedto)
        {
            return await _repository.CreateMovie(ApiHelper.CreateMovieDtoToEntity(createmoviedto));
        }

        public async Task DeleteMovie(int id)
        {
            await _repository.DeleteMovie(id);
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _repository.GetMovieById(id);
        }

        public async Task<List<ViewMovieDTO>> GetMovies()
        {
            List<ViewMovieDTO> list = new List<ViewMovieDTO>();
            List<Movie> movielist = await _repository.GetMovies();
            movielist.ForEach(m => list.Add(new ViewMovieDTO(m)));
            return list;
        }

        public async Task<List<Movie>> SerchMovie(string title, int? genderid)
        {
            return await _repository.SerchMovie(title, genderid);
        }

        public async Task UpdateMovie(UpdateMovieDTO updateMovieDto, int id)
        {
            Movie movie = await _repository.GetMovieById(id);
            if(movie == null)
            {
                return;
            }
            await _repository.UpdateMovie(ApiHelper.UpdateMovieToEntity(updateMovieDto,movie));
        }
    }
}
