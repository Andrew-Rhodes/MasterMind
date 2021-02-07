using MasterMind.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            Messages message = new Messages();
            GamePlay GP = new GamePlay();

            message.PlayStart();
            GP.StartNewGame();
            message.EndPlay();
        }
    }
}
