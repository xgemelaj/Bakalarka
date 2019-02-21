using ASP.NET_MVC_MajsterStrelby.Models;
using System.Web.Mvc;

namespace ASP.NET_MVC_MajsterStrelby.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        [Authorize]
        public ActionResult Index()
        {
            GameWordsModel gameWords = new GameWordsModel();
            gameWords.FillModel();

            return View(gameWords);
        }

        //// GET: Game/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Game/SendData
        [HttpPost]
        public ActionResult SendData(EndRoundWordsModels wordModel)
        {
            int finalPoints = 0;
            try
            {
                wordModel.userName = User.Identity.Name;
                //Function to calculate points for plazers answers
                finalPoints = wordModel.GetPoints();

                //
                //
                //Return points to new scene where will be showned points and possibility to play next game
                //
                //

                var result = new { Success = "True", Message = finalPoints };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                var result = new { Success = "False", Message = "Error" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Game/ShowPoints
        [Authorize]
        public ActionResult ShowPoints()
        {
            return View();
        }

        //// GET: Game/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Game/Edit/5
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

        //// GET: Game/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Game/Delete/5
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
