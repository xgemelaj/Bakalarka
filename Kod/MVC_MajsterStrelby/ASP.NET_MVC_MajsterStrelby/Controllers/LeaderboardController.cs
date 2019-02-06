using ASP.NET_MVC_MajsterStrelby.Models;
using ASP.NET_MVC_MajsterStrelby.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_MajsterStrelby.Controllers
{
    public class LeaderboardController : Controller
    {
        // GET: Leaderboard
        [Authorize]
        public ActionResult Index()
        {
            string conectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            var querry = "SELECT ih.id,ih.meno,COALESCE(SUM(zo.body),0) as body,COALESCE(COUNT(zo.id_hrac),0) as pocet " +
                            "FROM info_hrac ih " +
                            "LEFT JOIN zbieranie_ohodnoteni zo " +
                            "ON ih.id = zo.id_hrac " +
                            "GROUP BY ih.id,ih.meno ";
            DataTable dT = new DataTable();

            using (var connection = new SqlConnection(conectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                {
                    var commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(dT);
                }
            }

            var players = new List<Player>();
            foreach (DataRow row in dT.Rows)
            {
                //
                //DORATAT Z BODOV LEVEL
                //OBMEDZIT NA PIATICH A AKTUALNE PRIHLASENEHO
                //
                players.Add(new Player(Int32.Parse(row[0].ToString()), row[1].ToString(), Int32.Parse(row[2].ToString()), Int32.Parse(row[3].ToString())));
            }

            var playersViewModel = new PlayersViewModel
            {
                _players = players
            };

            return View(playersViewModel);
        }

        // GET: Leaderboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Leaderboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leaderboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Leaderboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Leaderboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Leaderboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Leaderboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
