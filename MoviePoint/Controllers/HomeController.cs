using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePoint.Data;
using MoviePoint.Models;
using System.Diagnostics;

namespace MoviePoint.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _Context = new ApplicationDbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var movies = _Context.Movies.Include(e => e.category).Include(e => e.cinema).ToList();
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
            return View(model: movies);
        }
        public IActionResult CategoryPage()
        {
            var categories = _Context.Categories.ToList();
            return View(model: categories);
        }
        public IActionResult CinemaPage()
        {
            var cinemas=_Context.Cinemas.ToList();
            return View(model:cinemas);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
