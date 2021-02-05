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
            Console.WriteLine("Let's Play MasterMind!");
            Console.WriteLine("Press 'Enter' to start");
            Console.ReadLine();

            GamePlay GP = new GamePlay();
            GP.StartNewGame();

            Console.WriteLine("Thanks for playing");
            Console.WriteLine("Press 'Enter' to End");
            Console.ReadLine();

        }
    }
}
