using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public class CurrentGameInfo
    {
        public List<int> Solution { get; set; }
        public List<int> PlayerSolution { get; set; }
        public List<string> KeyList { get; set; }
        public int Tries { get; set; }
    }
}
