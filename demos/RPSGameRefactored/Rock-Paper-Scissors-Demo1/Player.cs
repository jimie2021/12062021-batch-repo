using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Demo1
{
    internal class Player
    {
        public string Fname{ get; set; }
        public string Lname { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public Player(string fname, string lname)
        {
            this.Fname = fname;
            this.Lname = lname;
        }
    }
}
