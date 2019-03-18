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
        public string _taskWord { get; set; }
        public List<string> _possibleWords { get; set; }
        public Player _actualPlayer { get; set; }

        //public string GetTaskWord()
        //{
        //    return _taskWord;
        //}

        //public void SetTaskWord(string taskword)
        //{
        //    _taskWord = taskword;
        //}

        //public List<string> GetPossibleWords()
        //{
        //    return _possibleWords;
        //}

        //public void SetPossibleWords(List<string> possibleWords)
        //{
        //    _possibleWords = possibleWords;
        //}

        public GameWordsModel() { }

        public GameWordsModel(string taskWord, List<string> possibleWords)
        {
            this._taskWord = taskWord;
            this._possibleWords = possibleWords;
            //this.SetTaskWord(taskWord);
            //this.SetPossibleWords(possibleWords);
        }

        public void FillModel(string userName)
        {
            //Get information about actually logged in player
            this._actualPlayer = new Player();
            this._actualPlayer.FillInformation(userName);

            this.GenerateTaskWordFromDatabase();
            this.GeneratePossibleWordsFromDatabase();

        }

        private void GenerateTaskWordFromDatabase()
        {
            //Random generator to get task word for next round
            string conectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            //var querry = " SELECT TOP 1 prve_slovo FROM synonimicke_vztahy  ORDER BY NEWID()";
            var querry = " SELECT TOP 1 lemma FROM sk_lemmas_synonyms WHERE pos LIKE @Category  ORDER BY NEWID()";
            DataTable dT = new DataTable();

            using (var connection = new SqlConnection(conectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                {
                    //Only 50 words for people who making only few evaluation
                    if(_actualPlayer._level>7)
                        da.SelectCommand.Parameters.AddWithValue("@Category", "%");
                    else
                        da.SelectCommand.Parameters.AddWithValue("@Category", "A");
                    var commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(dT);
                }
            }
 
            this._taskWord = dT.Rows[0][0].ToString();
        }

        private void GeneratePossibleWordsFromDatabase()
        {
            //Calculate amount of words which need to be generate. This is affected by second skill - Visibility and base component - 5.
            int numberOfPossibleWords = 5;
            if((this._actualPlayer._skills[1])>3)
            {
                numberOfPossibleWords += 6 + (this._actualPlayer._skills[1] - 3) * 2;
            }
            else
            {
                numberOfPossibleWords += (this._actualPlayer._skills[1] - 1) * 3;
            }

            string conectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            //string querry = "SELECT TOP " + numberOfPossibleWords + " prve_slovo,druhe_slovo FROM synonimicke_vztahy WHERE prve_slovo LIKE @TaskWord OR prve_slovo LIKE @TaskWord ORDER BY NEWID()";
            string querry = "SELECT synset FROM sk_lemmas_synonyms WHERE lemma LIKE @TaskWord";
            DataTable dT = new DataTable();

            using (var connection = new SqlConnection(conectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                {
                    da.SelectCommand.Parameters.AddWithValue("@TaskWord", this._taskWord);
                    var commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(dT);
                }
            }

            //Get all words which have synonymous relationship to taskword to list and shuffle it to random order
            var allWords = dT.Rows[0][0].ToString().Split(',').ToList();
            allWords = ShuffleList<String>(allWords);

            //Create and fill specific count of possible words to list, we need to be sure that we are not at index that doesnt exist
            var possibleWords = new List<string>();
            var countOfWords = (numberOfPossibleWords - 1) > allWords.Count ? allWords.Count : (numberOfPossibleWords - 1);
            for (int i = 0; i < countOfWords; i++)
                possibleWords.Add(allWords[i]);

            //If not enough words, get random words from different taskword until we have amount of words which we needed
            while (possibleWords.Count < numberOfPossibleWords)
            {
                querry = "SELECT TOP 1 synset FROM sk_lemmas_synonyms WHERE lemma NOT LIKE @TaskWord ORDER BY NEWID()";

                dT = new DataTable();
                using (var connection = new SqlConnection(conectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@TaskWord", this._taskWord);
                        var commandBuilder = new SqlCommandBuilder(da);
                        da.Fill(dT);
                    }
                }

                //Get all words to list and shuffle it to random order
                allWords = dT.Rows[0][0].ToString().Split(',').ToList();
                allWords = ShuffleList<String>(allWords);

                //We need to be save that we are not at index that doesnt exist
                countOfWords = (numberOfPossibleWords - possibleWords.Count) > allWords.Count ? allWords.Count : (numberOfPossibleWords - possibleWords.Count);
                for (int i = 0; i < countOfWords; i++)
                    possibleWords.Add(allWords[i]);
            }


            //
            //
            //OLD WAY
            //
            //

            ////Create and fill possible words to list
            //var possibleWords = new List<string>();
            //for (int i = 0; i < dT.Rows.Count; i++)
            //    possibleWords.Add(dT.Rows[i][0].ToString() == this._taskWord ? dT.Rows[i][1].ToString() : dT.Rows[i][0].ToString());

            ////If not enough words, get random words different to taskword form database
            //if (possibleWords.Count < numberOfPossibleWords)
            //{
            //    var amount = numberOfPossibleWords - possibleWords.Count;
            //    var condition = "(";
            //    foreach (var item in possibleWords)
            //    {
            //        condition += "'" + item + "' ";
            //        if (possibleWords[possibleWords.Count - 1] != item)
            //            condition += ", ";
            //    }
            //    condition += ")";

            //    dT = new DataTable();
            //    querry = "SELECT TOP " + 2 * amount + " prve_slovo,druhe_slovo FROM synonimicke_vztahy " +
            //                "WHERE prve_slovo NOT IN " + condition + " AND druhe_slovo NOT IN " + condition + " ORDER BY NEWID()";

            //    using (var connection = new SqlConnection(conectionString))
            //    {
            //        using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
            //        {
            //            da.SelectCommand.Parameters.AddWithValue("@TaskWord", this._taskWord);
            //            var commandBuilder = new SqlCommandBuilder(da);
            //            da.Fill(dT);
            //        }
            //    }

            //    for (int i = 0; i < dT.Rows.Count; i++)
            //    {
            //        if (possibleWords.Count < numberOfPossibleWords && !possibleWords.Contains(dT.Rows[i][0]))
            //            possibleWords.Add(dT.Rows[i][0].ToString());
            //        if (possibleWords.Count < numberOfPossibleWords && !possibleWords.Contains(dT.Rows[i][1]))
            //            possibleWords.Add(dT.Rows[i][1].ToString());
            //    }
            //}

            //Set possible words to model
            //this.SetPossibleWords(possibleWords);
            this._possibleWords = possibleWords;
        }

        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }
    }
}