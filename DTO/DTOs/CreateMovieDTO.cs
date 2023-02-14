namespace ChallengeAlkemy.DTO.DTOs
{
    public class CreateMovieDTO
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public int Qualification { get; set; }
        public DateTime Creation { get; set; }
        public int GenderId { get; set; }
    }
}
