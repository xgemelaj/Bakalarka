using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace ASP.NET_MVC_MajsterStrelby.Models
{
    public class EndRoundWordsModels
    {
        public string[] choosenWords { get; set; } 
        public GameWordsModel model { get; set; }
        public string userName { get; set; }

        public int GetPoints()
        {
            //Get points for each selected pairs of words
            int[] points = this.CalculatePoints();
            int sum = points.Sum();

            //Insert to database data about round
            this.DataAboutRoundToDatabase(points);

            return sum;
        }

        private int[] CalculatePoints()
        {
            string conectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            int[] points = new int[this.choosenWords.Length];
            int counter = 0;

            //Loop for all choosen words
            foreach (var choosenWord in choosenWords)
            {
                //Select to find if same combination was selected in the past
                var querry = " SELECT vzdialenost FROM zbieranie_ohodnoteni WHERE prve_slovo LIKE @FirstWord AND druhe_slovo LIKE @SecondWord";
                DataTable dT = new DataTable();

                using (var connection = new SqlConnection(conectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                    {
                        if(string.Compare(model._taskWord, choosenWord) == -1)
                        {
                            da.SelectCommand.Parameters.AddWithValue("@FirstWord", model._taskWord);
                            da.SelectCommand.Parameters.AddWithValue("@SecondWord", choosenWord);
                        }
                        else
                        {
                            da.SelectCommand.Parameters.AddWithValue("@FirstWord", choosenWord);
                            da.SelectCommand.Parameters.AddWithValue("@SecondWord", model._taskWord);
                        }
                        
                        var commandBuilder = new SqlCommandBuilder(da);
                        da.Fill(dT);
                    }
                }

                //Check if same combination of words was choosen or not and calculate point
                foreach (DataRow row in dT.Rows)
                        points[counter] += (Int32.Parse(row[0].ToString()) == -1) ? -1 : 1;

                //Make value of points based on other player choices and selection priority
                points[counter] = MakeFinalAmount(points[counter],counter);
                counter++;
            }

            return points;
        }

        private int MakeFinalAmount(int quotient, int counter)
        {
            int maximumForOneChoice = 50;

            //Calculate points based on opinion of other players
            int finalAmount = (maximumForOneChoice / 10 * quotient) + maximumForOneChoice / 2;
            finalAmount = checkForCorrectness(maximumForOneChoice, finalAmount);

            //Calculate change of points due to quotient = priority choose
            double helpAmount = finalAmount / (1 + 0.05 * (counter));
            finalAmount = (int)helpAmount;
 
            //
            //
            //DORATAT BONUS ZA SKILL
            //
            //

            return finalAmount;
        }

        private int checkForCorrectness(int maximumForOneChoice, int finalAmount)
        {
            //Check for restricted bordes of value
            if (finalAmount >= 0 && finalAmount <= maximumForOneChoice)
                return finalAmount;
            else
                return finalAmount < 0 ? 0 : maximumForOneChoice;
        }

        private void DataAboutRoundToDatabase(int[] points)
        {
            string conectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            int counter = 0;
            List<string> allWords = this.model._possibleWords;
            using (var connection = new SqlConnection(conectionString))
            {
                connection.Open();

                //Find ID of player which is log in
                var querry = "SELECT id FROM info_hrac WHERE meno LIKE '" + this.userName + "'";
                DataTable dT = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                {
                    var commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(dT);
                }

                int actualPlayerId = Int32.Parse(dT.Rows[0][0].ToString());

                //Insert into database synonymous relationships whit distances
                foreach (var choosenWord in choosenWords)
                {
                    querry = "INSERT INTO zbieranie_ohodnoteni (id_hrac, prve_slovo, druhe_slovo, vzdialenost, body) VALUES(@IdPlayer, @FirstWord, @SecondWord, @Distance, @Points)";

                    using (var cmd = new SqlCommand(querry, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdPlayer", actualPlayerId);
                        if (string.Compare(model._taskWord, choosenWord) == -1)
                        {
                            cmd.Parameters.AddWithValue("@FirstWord", model._taskWord);
                            cmd.Parameters.AddWithValue("@SecondWord", choosenWord);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@FirstWord", choosenWord);
                            cmd.Parameters.AddWithValue("@SecondWord", model._taskWord);
                        }
                        cmd.Parameters.AddWithValue("@Distance", counter+1);
                        cmd.Parameters.AddWithValue("@Points", points[counter]);

                        cmd.ExecuteNonQuery();
                    }
                    counter++;

                    allWords.RemoveAt(allWords.IndexOf(choosenWord));
                }

                //Insert to database words that werent choosen and give tham distance value -1
                foreach(var word in allWords)
                {
                    querry = "INSERT INTO zbieranie_ohodnoteni (id_hrac, prve_slovo, druhe_slovo, vzdialenost, body) VALUES(@IdPlayer, @FirstWord, @SecondWord, @Distance, @Points)";

                    using (var cmd = new SqlCommand(querry, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdPlayer", actualPlayerId);
                        if (string.Compare(model._taskWord, word) == -1)
                        {
                            cmd.Parameters.AddWithValue("@FirstWord", model._taskWord);
                            cmd.Parameters.AddWithValue("@SecondWord", word);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@FirstWord", word);
                            cmd.Parameters.AddWithValue("@SecondWord", model._taskWord);
                        }
                        cmd.Parameters.AddWithValue("@Distance", counter + 1);
                        cmd.Parameters.AddWithValue("@Points", -1);

                        cmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }
    }


}