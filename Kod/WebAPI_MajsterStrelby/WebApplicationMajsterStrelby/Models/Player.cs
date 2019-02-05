using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMajsterStrelby.Models
{
    public class Player
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public int _points { get; set; }
        public int _resolved { get; set; }

        public Player(int id, string name, int points, int resolved)
        {
            _id = id;
            _name = name;
            _points = points;
            _resolved = resolved;
        }
    }
}