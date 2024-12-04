using System.ComponentModel.DataAnnotations;

namespace MoviePoint.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public string TrailerUrl { get; set; }
        public MovieStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CategoryId { get; set; }
        public int CinemaId { get; set; }
        public Category category { get; set; }
        public Cinema cinema { get; set; }
        public ICollection<ActorMovie> ActorMovies { get; } = new List<ActorMovie>();
    }
}
