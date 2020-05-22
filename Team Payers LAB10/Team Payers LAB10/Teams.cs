using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Payers_LAB10
{
    class Team
    {
        // Properties
        public string Name { get; set; }
        public string Code { get; set; }
        public string Founded { get; set; }

        public List<Player> Players { get; set; } 

        // Constuctors
        public Team()
        {
            Players = new List<Player>();
            Name = "";
            Code = "";
            Founded = "";
        }
    }
}
