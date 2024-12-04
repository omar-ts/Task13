using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePoint.Data;

namespace MoviePoint.Controllers
{
    public class MovieDetailController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index(int id)
        {
            var movies = _context.Movies.Include(e => e.category).Include(e=>e.cinema).Include(e => e.ActorMovies).FirstOrDefault(e => e.Id == id);
            _context.Actors.Include(e => e.ActorMovies).ToList();

            if (DateTime.Now > movies.EndDate)
            {
                movies.Status = MovieStatus.Expired;
            }
            else if (DateTime.Now < movies.StartDate)
            {
                movies.Status = MovieStatus.Upcoming;
            }
            return View(model: movies);
        }
    }
}
