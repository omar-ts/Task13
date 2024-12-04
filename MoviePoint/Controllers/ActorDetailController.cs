using Microsoft.AspNetCore.Mvc;
using MoviePoint.Data;

namespace MoviePoint.Controllers
{
    public class ActorDetailController : Controller
    {
        ApplicationDbContext _content = new ApplicationDbContext();
        public IActionResult Index(int id)
        {
            var actor = _content.Actors.Find(id);
            return View(model: actor);
        }
    }
}
