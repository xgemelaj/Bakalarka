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
            playersViewModel.FillPlayersFromDatabase();

            return View(playersViewModel);
        }

        //// GET: Leaderboard/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Leaderboard/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Leaderboard/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Leaderboard/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Leaderboard/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Leaderboard/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Leaderboard/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
