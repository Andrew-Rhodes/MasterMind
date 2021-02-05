using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public class GenerateSolution
    {
        public List<int> GenerateGameSolution()
        {
            Random rnd = new Random();
            List<int> GameSolution = new List<int>();

            for (int x = 0; x < 4; x++)
            {
                int randomNumber = rnd.Next(1, 7);

                //Console.WriteLine(randomNumber);
                GameSolution.Add(randomNumber);
            }

            return GameSolution;
        }
    }
}
