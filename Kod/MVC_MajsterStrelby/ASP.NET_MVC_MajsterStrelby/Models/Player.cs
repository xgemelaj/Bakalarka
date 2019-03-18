﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_MajsterStrelby.Models
{
    public class Player
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public int _points { get; set; }
        public int _level { get; set; }
        public int _resolved { get; set; }
        public int[] _skills { get; set; }

        public Player() {}

        public Player(int id, string name, int points, int resolved)
        {
            _id = id;
            _name = name;
            _points = points;
            this.CalculateLevel();
            _resolved = resolved;
        }

        public void FillInformation(string playerName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            var querry = "SELECT ih.id,ih.meno,COALESCE(SUM(zo.body),0) as body,COALESCE(COUNT(zo.id_hrac),0) as pocet " +
                            "FROM info_hrac ih " +
                            "LEFT JOIN zbieranie_ohodnoteni zo " +
                            "ON ih.id = zo.id_hrac " +
                            "WHERE zo.vzdialenost <> -1 AND ih.id = @IdPlayer " +
                            "GROUP BY ih.id,ih.meno " +
                            "ORDER BY body DESC";
            DataTable dT = new DataTable();
            var idPlayer = FindIdPlayer(playerName, connectionString);

            using (var connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                {
                    da.SelectCommand.Parameters.AddWithValue("IdPlayer", idPlayer);
                    var commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(dT);
                }
            }

            if(dT.Rows.Count>0)
            {
                this._id = Int32.Parse(dT.Rows[0][0].ToString());
                this._name = dT.Rows[0][1].ToString();
                this._points = Int32.Parse(dT.Rows[0][2].ToString());
                this._resolved = Int32.Parse(dT.Rows[0][3].ToString());
            }
            else
            {
                //If not played any game
                querry = "SELECT ih.id,ih.meno FROM info_hrac ih WHERE ih.id = @IdPlayer ";
                dT = new DataTable();
                using (var connection = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                    {
                        da.SelectCommand.Parameters.AddWithValue("IdPlayer", idPlayer);
                        var commandBuilder = new SqlCommandBuilder(da);
                        da.Fill(dT);
                    }
                }

                this._id = Int32.Parse(dT.Rows[0][0].ToString());
                this._name = dT.Rows[0][1].ToString();
                this._points = 0;
                this._resolved = 0;
            }
            //this._id = Int32.Parse(dT.Rows[0][0].ToString());
            //this._name = dT.Rows[0][1].ToString();
            //this._points = Int32.Parse(dT.Rows[0][2].ToString());
            this.CalculateLevel();
            //this._resolved = Int32.Parse(dT.Rows[0][3].ToString());
            this._skills = FillSkills(connectionString);
        }

        public void UpgradeSkill(string upgradeSkillButton)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultSqlConnection"].ConnectionString;
            int skill = Int32.Parse(upgradeSkillButton);
            int levelOfSkill = this._skills[skill];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string querry = "INSERT INTO zrucnosti (id_hrac, atribut, level_atributu) VALUES(@IdPlayer, @Skill, @SkillLevel)";

                using (var cmd = new SqlCommand(querry, connection))
                {
                    cmd.Parameters.AddWithValue("@IdPlayer", this._id);
                    cmd.Parameters.AddWithValue("@Skill", skill);
                    cmd.Parameters.AddWithValue("@SkillLevel", levelOfSkill+1);

                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private int FindIdPlayer(string playerName, string conectionString)
        {
            //Find ID of player which is log in
            var querry = "SELECT id FROM info_hrac WHERE meno LIKE '" + playerName + "'";
            DataTable dT = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(querry, conectionString))
            {
                var commandBuilder = new SqlCommandBuilder(da);
                da.Fill(dT);
            }

            return Int32.Parse(dT.Rows[0][0].ToString());
        }

        private void CalculateLevel()
        {
            double thirthParth = this._points / 50;

            this._level = QuadraticEquation(1, -1, -thirthParth);
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

        private int[] FillSkills(string connectionString)
        {
            int[] skills = new int[4] { 1, 1, 1, 1 };

            var querry = "SELECT z.atribut,MAX(z.level_atributu) " +
                            "FROM info_hrac ih " +
                            "LEFT JOIN zrucnosti z " +
                            "ON ih.id = z.id_hrac " +
                            "WHERE ih.id = @IdPlayer " +
                            "GROUP BY z.atribut " ;
                           
            DataTable dT = new DataTable();

            using (var connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(querry, connection))
                {
                    da.SelectCommand.Parameters.AddWithValue("IdPlayer", this._id);
                    var commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(dT);
                }
            }

            //If player dont have information about skills, we send to database all skills on level 1 what is starting position
            if(dT.Rows.Count < 4)
                SetBasicSkillsSettingInDatabase(connectionString);

            //If player have information about skills in database we send them as a return
            else
                for(int i=0; i<4; i++)
                    skills[i] = Int32.Parse(dT.Rows[i][1].ToString());

            return skills;
        }

        //Setup Basic level of all skills to 1
        private void SetBasicSkillsSettingInDatabase(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 0; i < 4; i++)
                {
                    string querry = "INSERT INTO zrucnosti (id_hrac, atribut, level_atributu) VALUES(@IdPlayer, @Skill, @SkillLevel)";

                    using (var cmd = new SqlCommand(querry, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdPlayer", this._id);
                        cmd.Parameters.AddWithValue("@Skill", i);
                        cmd.Parameters.AddWithValue("@SkillLevel", 1);

                        cmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }

        public int CountPossibleSkillUpgrades()
        {
            //First we need to know how many upgrades he could make because of his level
            int possibleUpgrades = this._level / 5;
            //Than we remove alreaty assigned skill points 
            for (int i = 0; i < this._skills.Length; i++)
                possibleUpgrades -= (this._skills[i] - 1);

            return possibleUpgrades;
        }
    }
}