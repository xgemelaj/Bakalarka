using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_MajsterStrelby.Models
{
    public class GameWordsModel
    {
        private string _taskWord;
        private List<string> _possibleWords;

        public string GetTaskWord()
        {
            return _taskWord;
        }

        public void SetTaskWord(string taskword)
        {
            _taskWord = taskword;
        }

        public List<string> GetPossibleWords()
        {
            return _possibleWords;
        }

        public void SetPossibleWords(List<string> possibleWords)
        {
            _possibleWords = possibleWords;
        }

        public GameWordsModel() { }

        public GameWordsModel(string taskWord, List<string> possibleWords)
        {
            this.SetTaskWord(taskWord);
            this.SetPossibleWords(possibleWords);
        }

        public void FillModel()
        {
            this.GenerateTaskWordFromDatabase();
            this.GeneratePossibleWordsFromDatabase(this.GetTaskWord());
        }

        private void GenerateTaskWordFromDatabase()
        {
            string conectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            var querry = " SELECT TOP 1 prve_slovo FROM synonimicke_vztahy  ORDER BY NEWID()";
            DataTable dT = new DataTable();

            using (var connection = new SqlConnection(conectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                {
                    var commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(dT);
                }
            }

            //Random generator to get task word for next round 
            this.SetTaskWord(dT.Rows[0][0].ToString());
        }

        private void GeneratePossibleWordsFromDatabase(string taskWord)
        {
            string conectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            string querry = "SELECT TOP 5 prve_slovo,druhe_slovo FROM synonimicke_vztahy WHERE prve_slovo LIKE @TaskWord OR prve_slovo LIKE @TaskWord ORDER BY NEWID()";
            DataTable dT = new DataTable();

            using (var connection = new SqlConnection(conectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                {
                    da.SelectCommand.Parameters.AddWithValue("@TaskWord", taskWord);
                    var commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(dT);
                }
            }

            //Create and fill possible words to list
            var possibleWords = new List<string>();
            for (int i = 0; i < dT.Rows.Count; i++)
                possibleWords.Add(dT.Rows[i][0].ToString() == taskWord ? dT.Rows[i][1].ToString() : dT.Rows[i][0].ToString());

            //If not enough words, get random words different to taskword form database
            if (possibleWords.Count < 5)
            {
                var amount = 5 - possibleWords.Count;
                var condition = "(";
                foreach (var item in possibleWords)
                {
                    condition += "'" + item + "' ";
                    if (possibleWords[possibleWords.Count - 1] != item)
                        condition += ", ";
                }
                condition += ")";

                dT = new DataTable();
                querry = "SELECT TOP " + 2 * amount + " prve_slovo,druhe_slovo FROM synonimicke_vztahy " +
                            "WHERE prve_slovo NOT IN " + condition + " AND druhe_slovo NOT IN " + condition + " ORDER BY NEWID()";

                using (var connection = new SqlConnection(conectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@TaskWord", taskWord);
                        var commandBuilder = new SqlCommandBuilder(da);
                        da.Fill(dT);
                    }
                }

                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    if (possibleWords.Count < 5 && !possibleWords.Contains(dT.Rows[i][0]))
                        possibleWords.Add(dT.Rows[i][0].ToString());
                    if (possibleWords.Count < 5 && !possibleWords.Contains(dT.Rows[i][1]))
                        possibleWords.Add(dT.Rows[i][1].ToString());
                }
            }

            //Set possible words to model
            this.SetPossibleWords(possibleWords);
        }
    }
}