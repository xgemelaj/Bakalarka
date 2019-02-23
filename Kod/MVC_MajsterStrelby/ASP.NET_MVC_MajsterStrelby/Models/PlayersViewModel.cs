using ASP.NET_MVC_MajsterStrelby.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ASP.NET_MVC_MajsterStrelby.Models
{
    public class PlayersViewModel
    {
        private List<Player> _players;

        public List<Player> GetPlayers()
        {
            return _players;
        }

        public void SetPlayers(List<Player> players)
        {
            _players = players;
        }

        public PlayersViewModel() {}

        public PlayersViewModel(List<Player> players)
        {
            this.SetPlayers(players);
            //this._players = players;
        }

        public void FillPlayersFromDatabase()
        {
            string conectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            var querry = "SELECT ih.id,ih.meno,COALESCE(SUM(zo.body),0) as body,COALESCE(COUNT(zo.id_hrac),0) as pocet " +
                            "FROM info_hrac ih " +
                            "LEFT JOIN zbieranie_ohodnoteni zo " +
                            "ON ih.id = zo.id_hrac " +
                            "GROUP BY ih.id,ih.meno " +
                            "ORDER BY body DESC";
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
                //Calculate level based on players experience
                int level = CalculateLevel(Int32.Parse(row[2].ToString()));

                players.Add(new Player(Int32.Parse(row[0].ToString()), row[1].ToString(), level, Int32.Parse(row[3].ToString())));
            }

            this.SetPlayers(players);
        }

        private int CalculateLevel(int experiences)
        {
            double thirthParth = experiences / 50;

            return QuadraticEquation(1, -1, -thirthParth);
        }

        private int QuadraticEquation(double a, double b, double c)
        {
            double inside = (b * b) - 4 * a * c;
            double x1 = 0;
            double x2 = 0;

            if (inside < 0)
            {
                x1 = double.NaN;
                x2 = double.NaN;
            }
            else
            {
                double eqn = Math.Sqrt(inside);
                x1 = (-b + eqn) / (2 * a);
                x2 = (-b - eqn) / (2 * a);
            }

            return x1 > x2 ? (int)x1 : (int)x2;
        }
    }
}