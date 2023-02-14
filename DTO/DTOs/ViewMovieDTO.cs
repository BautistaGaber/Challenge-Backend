using ChallengeAlkemy.Models;
using System.Drawing;

namespace ChallengeAlkemy.DTO.DTOs
{
    public class ViewMovieDTO
    {
        public string Image { get; set; }   
        public string Title { get; set; }
        public DateTime Creation { get; set; }

        public ViewMovieDTO(Movie m)
        {
            Image = m.Image;
            Title = m.Title;
            Creation = m.Creation;
        }
    }
}
