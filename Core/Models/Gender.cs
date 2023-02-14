using System.ComponentModel.DataAnnotations;

namespace ChallengeAlkemy.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }

       public List<Movie> Movies { get; set; }

        //public Gender()
        //{
        //    Movies = new List<Movie>();
        //}

        //public Gender(string name, string image)
        //    : base()
        //{
        //    Name = name;
        //    Image = image;
        //}


    }
}
