using Microsoft.EntityFrameworkCore;
using MoviePoint.Models;

namespace MoviePoint.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Movie>Movies { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Cinema>Cinemas { get; set; }
        public DbSet<Actor>Actors { get; set; }
        public DbSet<ActorMovie>ActorMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Etickets;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>()
                .Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}
