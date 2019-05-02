using ASP.NET_MVC_MajsterStrelby.Models;
using System.Web.Mvc;

namespace ASP.NET_MVC_MajsterStrelby.Controllers
{
    public class LeaderboardController : Controller
    {
        // GET: Leaderboard
        [Authorize]
        public ActionResult Index()
        {
            var playersViewModel = new PlayersViewModel();
            playersViewModel.FillPlayersFromDatabase(User.Identity.Name);

            return View(playersViewModel);
        }
    }
}
