using ChallengeAlkemy.DTO.MoviesDTO;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlkemy.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public decimal Weight { get; set; }

        [Required]
        [Display(Name = "History")]
        public string History { get; set; }

        public ICollection<Movie> Movie { get; set; } = new List<Movie>();

        public List<FullMovieDTO> ConvertoDTO(List<Movie> movies)
        {
            List<FullMovieDTO> movieList = new List<FullMovieDTO>();
            movies.ForEach(m => movieList.Add(new FullMovieDTO(m)));
            return movieList;
        }
        //public Character(string image, string name, int age, decimal weight, string history)
        //    : base()
        //{
        //    Image = image;
        //    Name = name;
        //    Age = age;
        //    Weight = weight;
        //    History = history;
        //}
        //public void AddMovie(Movie movie)
        //{
        //    try
        //    {
        //      Movies.Add(new CharacterMovie { Movie = movie, Character = this });
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}
        //public List<CharacterMovie> GetMovies()
        //{
        //    return Movies;
        //}




    }
}
