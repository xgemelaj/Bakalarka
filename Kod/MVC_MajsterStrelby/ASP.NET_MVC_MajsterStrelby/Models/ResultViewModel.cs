using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ASP.NET_MVC_MajsterStrelby.Models
{
    public class ResultViewModel
    {
        public int _finalPoints { get; set; }
        public string _taskWord { get; set; }
        public string[] _orderedWords { get; set; }
        public double[] _wordsPercentage { get; set; }

        internal void FillModel(int finalPoints, string userName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;

            //Assign final points to the ViewModel
            this._finalPoints = finalPoints;

            //Get last TaskWord which was completed with current User
            var querry = "SELECT TOP 1 zo.prve_slovo FROM zbieranie_ohodnoteni zo LEFT JOIN info_hrac ih ON ih.id = zo.id_hrac WHERE ih.meno LIKE @PlayerName ORDER BY zo.id DESC";
            DataTable dT = new DataTable();
            using (var connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                {
                    da.SelectCommand.Parameters.AddWithValue("PlayerName", userName);
                    var commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(dT);
                }
            }

            //Make last taskword in database the current taskword
            if (dT.Rows.Count > 0)
                this._taskWord = dT.Rows[dT.Rows.Count-1][0].ToString();
            
            //Make order of words to challenging taskword

            querry = "SELECT part.druhe_slovo, part.points * 1.0/part.amount * 1.0 as coefficient " +
                            "FROM( " +
                                "SELECT druhe_slovo, SUM(vzdialenost) as points, COUNT(druhe_slovo) as amount " +
                                "FROM zbieranie_ohodnoteni WHERE prve_slovo LIKE @TaskWord GROUP BY druhe_slovo " +
                            ") as part " +
                            "WHERE part.points > 0 " +
                            "ORDER BY coefficient DESC, amount ASC";
            dT = new DataTable();

            using (var connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                {
                    da.SelectCommand.Parameters.AddWithValue("TaskWord", _taskWord);
                    var commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(dT);
                }
            }

            string[] wordsOrder = new string[dT.Rows.Count];
            double[] wordsPercentage = new double[dT.Rows.Count];
            double sum = 0;

            if (dT.Rows.Count > 0)
            {
                //Get sum of all values to calculate correct percentage of each word
                foreach (DataRow row in dT.Rows)
                    sum += Double.Parse(row[1].ToString());

                for(int i=0; i<dT.Rows.Count; i++)
                {
                    if(Double.Parse(dT.Rows[i][1].ToString()) > 0)
                    {
                        wordsOrder[i] = dT.Rows[i][0].ToString();
                        wordsPercentage[i] = Double.Parse(dT.Rows[i][1].ToString()) / sum;
                    }
                }
            }

            //Assign Order of Words and their percentage from evaluations to ViewModel
            this._orderedWords = wordsOrder;
            this._wordsPercentage = wordsPercentage;
        }
    }
}