using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ChallengeAlkemy.DTO.DTOs
{
    public class FullCharacterDTO
    {
        
        public string Image { get; set; }       
        public string Name { get; set; }  
        public int Age { get; set; }   
        public decimal Weight { get; set; }
        public string History { get; set; }
        public List<FullMovieDTO> fullMovieDTOs { get; set; }

        public FullCharacterDTO()
        {
            fullMovieDTOs = new List<FullMovieDTO>();   
        }

        public FullCharacterDTO(Character c)
            : base()
        {
            Image = c.Image;
            Name = c.Name;  
            Age = c.Age;    
            Weight = c.Weight;
            History = c.History;
            fullMovieDTOs = c.ConvertoDTO((List<Movie>)c.Movie);
        }
    }
}
