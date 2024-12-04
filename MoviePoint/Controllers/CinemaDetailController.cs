using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePoint.Data;

namespace MoviePoint.Controllers
{
    public class CinemaDetailController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index(int id)
        {
            var cinema = _context.Cinemas.Include(e => e.Movies).FirstOrDefault(e => e.Id == id);
            var movies = _context.Movies.Include(e => e.category).ToList();
            foreach (var item in movies)
            {
                if (DateTime.Now > item.EndDate)
                {
                    item.Status = MovieStatus.Expired;
                }
                else if (DateTime.Now < item.StartDate)
                {
                    item.Status = MovieStatus.Upcoming;
                }
            }
            return View(cinema);
        }
    }
}
