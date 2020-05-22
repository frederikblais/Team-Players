using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Payers_LAB10
{
    class Player
    {
        // Properties
        public string FullName { get; set; }
        public string Pos { get; set; }
        public int Gp { get; set; }
        public int G { get; set; }
        public int A { get; set; }
        public int Sog { get; set; }

        // Constructors
        public Player()
        {
            FullName = "";
            Pos = "";
            Gp = 0;
            G = 0;
            A = 0;
            Sog = 0;
        }
    }
}
