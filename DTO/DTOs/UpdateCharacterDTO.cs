using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ChallengeAlkemy.DTO.DTOs
{
    public class UpdateCharacterDTO
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public string History { get; set; }
    }
}
