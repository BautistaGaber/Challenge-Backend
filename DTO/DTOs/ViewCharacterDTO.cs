using ChallengeAlkemy.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ChallengeAlkemy.DTO.MoviesDTO
{
    public class ViewCharacterDTO
    {
        public string Image { get; set; }
        public string Name { get; set; }

        public ViewCharacterDTO(Character c)
        {
            Image = c.Image;
            Name = c.Name;
        }
    }

}
