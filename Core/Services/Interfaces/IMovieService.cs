using ChallengeAlkemy.DTO.DTOs;
using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAlkemy.Core.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<ViewMovieDTO>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task<List<Movie>> SerchMovie(string title, int? genderid);
        Task<Movie> CreateMovie(CreateMovieDTO movieDTO);
        Task UpdateMovie(UpdateMovieDTO updateMovieDto, int id);
        Task DeleteMovie(int id);
    }
}
