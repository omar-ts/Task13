using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePoint.Data;

namespace MoviePoint.Controllers
{
    public class FindPageController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index(string MovieName)
        {
            var movies = _context.Movies.Include(e => e.category).Include(e => e.cinema).Where(e => e.Name.Contains(MovieName)).ToList();
            if (!movies.Any())
            {
                return RedirectToAction(nameof(NotFoundPage));
            }
            return View(movies);
        }
        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}
