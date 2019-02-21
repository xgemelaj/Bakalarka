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

            this.SetPlayers(players);
        }
    }
}