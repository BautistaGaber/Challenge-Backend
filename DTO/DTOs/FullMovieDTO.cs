using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ChallengeAlkemy.DTO.DTOs;
using ChallengeAlkemy.Models;

namespace ChallengeAlkemy.DTO.MoviesDTO
{
    public class FullMovieDTO
    {      
        public string Image { get; set; }      
        public string Title { get; set; }       
        public int Qualification { get; set; }   
        public DateTime Creation { get; set; }      
        public int GenderId { get; set; }
        public List<FullCharacterDTO> fullcharacterdtos { get; set; }

        public FullMovieDTO()
        {
            fullcharacterdtos = new List<FullCharacterDTO>();
        }

        public FullMovieDTO(Movie m)
        {
            Image = m.Image;
            Title = m.Title;
            Qualification = m.Qualification;
            Creation = m.Creation;
            GenderId = m.GenderId;
            fullcharacterdtos = m.ConvertoDTO((List<Character>)m.Character);
        }
    }
}
