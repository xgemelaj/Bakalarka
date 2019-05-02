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
            gameWords.FillModel(User.Identity.Name);

            return View(gameWords);
        }

        // POST: Game/SendData
        [Authorize]
        [HttpPost]
        public ActionResult SendData(EndRoundWordsModels wordModel)
        {
            int finalPoints = 0;
            int oldLevel = wordModel.model._actualPlayer._level;
            TempData["message"] = "";
            try
            {
                wordModel.userName = User.Identity.Name;
                //Function to calculate points for plazers answers
                finalPoints = wordModel.GetPoints();

                //Make sure if some achievment need to be update and then return if some of them was updated
                bool updateAchievments = wordModel.model._actualPlayer.UpdateAchievments(finalPoints);
                if(updateAchievments==true)
                {
                    TempData["message"] += "A";
                }

                //Check if player can upgrade skill
                if(oldLevel/5 < wordModel.model._actualPlayer._level/5)
                {
                    if(TempData["message"] == "A")
                        TempData["message"] = "V";
                    else
                        TempData["message"] += "S";
                }

                var result = new { Success = "True", Message = finalPoints };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                var result = new { Success = "False", Message = "Error" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Game/Result/85
        [Authorize]
        public ActionResult Result(int id)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            resultViewModel.FillModel(id, User.Identity.Name);

            return View(resultViewModel);
        }
    }
}
