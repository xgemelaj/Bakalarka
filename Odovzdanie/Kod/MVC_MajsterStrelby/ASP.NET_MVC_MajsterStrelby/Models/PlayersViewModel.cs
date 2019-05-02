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
        private Player _actualPlayer;

        public List<Player> GetPlayers()
        {
            return _players;
        }

        public Player GetActualPlayer()
        {
            return _actualPlayer;
        }

        public void SetPlayers(List<Player> players)
        {
            _players = players;
        }

        public void SetActualPlayer(Player player)
        {
            _actualPlayer = player;
        }

        public PlayersViewModel(){}

        public PlayersViewModel(List<Player> players)
        {
            this.SetPlayers(players);
            //this._players = players;
        }

        public void FillPlayersFromDatabase(string userName)
        {
            string conectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            var querry = "SELECT TOP 5 ih.id,ih.meno,COALESCE(SUM(zo.body),0) as body,COALESCE(COUNT(zo.id_hrac),0) as pocet " +
                            "FROM info_hrac ih " +
                            "LEFT JOIN zbieranie_ohodnoteni zo " +
                            "ON ih.id = zo.id_hrac " +
                            "WHERE zo.vzdialenost <> -1 " + 
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
                //Create Player with selected stats
                players.Add(new Player(Int32.Parse(row[0].ToString()), row[1].ToString(), Int32.Parse(row[2].ToString()), Int32.Parse(row[3].ToString())));
            }

            this.SetPlayers(players);
            this.SetActualPlayer(new Player());
            //Fill information about actual player
            _actualPlayer.FillInformation(userName);
        }
    }
}