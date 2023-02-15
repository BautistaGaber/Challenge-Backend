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
    }
}
