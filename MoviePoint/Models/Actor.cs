namespace MoviePoint.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public string News { get; set; }
        public ICollection<ActorMovie> ActorMovies { get; }=new List<ActorMovie>();
    }
}
