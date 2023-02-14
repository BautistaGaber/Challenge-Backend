using ChallengeAlkemy.DTO.DTOs;
using ChallengeAlkemy.DTO.MoviesDTO;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlkemy.Models
{
    public class Movie
    {

        private int _qualification;

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Creation")]
        public DateTime Creation { get; set; }

        [Required]
        [Display(Name = "Qualification")]
        public int Qualification
        {
            get { return _qualification; }
            set
            {
                if (value < 1 || value > 5)
                    throw new Exception("La calificacion es invalida");

                _qualification = value;
            }
        }

        [Required]
        [Display(Name = "Gender_Id")]
        public int GenderId { get; set; }

        public ICollection<Character> Character { get; set; } = new List<Character>();

        public List<FullCharacterDTO> ConvertoDTO(List<Character> character)
        {
            List<FullCharacterDTO> characterlist = new List<FullCharacterDTO>();
            character.ForEach(c => characterlist.Add(new FullCharacterDTO(c)));
            return characterlist;
        }

        public Movie()
        {
        }
    }
}
