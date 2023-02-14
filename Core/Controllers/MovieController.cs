using ChallengeAlkemy.Core.Repositories.Interfaces;
using ChallengeAlkemy.Core.Services.Interfaces;
using ChallengeAlkemy.DTO.DTOs;
using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ChallengeAlkemy.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(await _service.GetMovies());
        }

        [HttpGet]
        [Route("/buscarPelicula/{id}")]
        public async Task<IActionResult> GetMoviesById([FromRoute] int id)
        {
            return Ok(await _service.GetMovieById(id));
        }

        [HttpGet]
        [Route("/buscarPelicula")]
        public async Task<IActionResult> SerchMovie([FromQuery]string title, [FromQuery] int gender)
        {
            return Ok(await _service.SerchMovie(title, gender));
        }

        [HttpPost]
        //[Route("createMovie")]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieDTO movieDTO)
         {
            var result = await _service.CreateMovie(movieDTO);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(Movie movie)
        {
            var result = _service.UpdateMovie(movie);
            if( result == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie =  _service.DeleteMovie(id);
            if (movie == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
    }
}
