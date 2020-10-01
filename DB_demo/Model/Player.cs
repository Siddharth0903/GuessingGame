using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Player
    {
       public int id { get; set; }
        public string name { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }

        public Player()
        {

        }
        public Player( int id,string name, int wins, int losses, int ties)
        {
            
            this.name = name;
            this.wins = wins;
            this.losses = losses;
            this.ties = ties;
        }
      


    }
}
