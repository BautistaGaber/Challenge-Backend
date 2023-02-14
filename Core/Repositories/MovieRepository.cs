using ChallengeAlkemy.Core.Repositories.Interfaces;
using ChallengeAlkemy.Data;
using ChallengeAlkemy.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using ChallengeAlkemy.DTO.MoviesDTO;

namespace ChallengeAlkemy.Core.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AplicationDbContext _context;

        public MovieRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            _context.SaveChanges();
            return movie;
        }

        public async Task DeleteMovie(int id)
        {
            var result = await _context.Movies.FirstOrDefaultAsync(c => c.Id == id);
            _context.Movies.Remove(result);
            await SaveChanges();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var result = await _context.Movies.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public async Task UpdateMovie(Movie movie)
        {
           _context.Movies.Update(movie);
        }

        public async Task<List<Movie>> SerchMovie(string title, int? genderid)
        {
            var ordersmovies = _context.Movies.OrderByDescending(c => title);
            return await _context.Movies.
                Where(e => e.Title == title || title == null &&
                e.GenderId == genderid || genderid == null).ToListAsync();
        }
    }
}
