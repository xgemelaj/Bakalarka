using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_MajsterStrelby.Models
{
    public class Vocabulary
    {
        public void CreateVocabulary()
        {
            string conectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            var querry = "SELECT prve_slovo, druhe_slovo, COUNT(druhe_slovo) as amount, SUM(vzdialenost) * 1.0 / COUNT(druhe_slovo) * 1.0 as coefficient " +
                            "FROM zbieranie_ohodnoteni " +
                            "JOIN sk_lemmas_synonyms sls " +
                            "ON prve_slovo = sls.lemma " +
                            "WHERE sls.pos LIKE 'A' " +
                            "GROUP BY prve_slovo, druhe_slovo " +
                            "HAVING COUNT(druhe_slovo) > 1 " +
                            "ORDER BY prve_slovo ASC, coefficient DESC, amount ASC";

            DataTable dT = new DataTable();
            using (var connection = new SqlConnection(conectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                {
                    var commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(dT);
                }
            }

            string path = @"D:\School\Bakalarka\Slovnik\vocabulary.txt";
            
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            
            //Create and fill file
            using (var tw = new StreamWriter(path, true))
            {
                string firstWord = null;
                int counter = 0;
                foreach(DataRow dr in dT.Rows)
                {
                    if(dr[0].ToString() != firstWord)
                    {
                        if (firstWord != null)
                            tw.WriteLine();

                        firstWord = dr[0].ToString();
                        tw.Write(firstWord + " -  ");
                        counter = 0;
                    }

                    if(counter<4)
                        tw.Write(dr[1].ToString() + ", ");
                    counter++;
                }
            }
        }
    }
}