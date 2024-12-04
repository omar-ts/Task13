using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePoint.Data;
using MoviePoint.Models;

namespace MoviePoint.Controllers
{
    public class CategoryDetailController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index(int id)
        {
            var category = _context.Categories.Include(e => e.Movies).FirstOrDefault(e => e.Id == id);
            var movies = _context.Movies.Include(e => e.cinema).ToList();
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
            return View(model: category);
        }
    }
}
