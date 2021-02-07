using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Logic
{
    public class ModelBuilder
    {
        public CurrentGameInfo GetStartModel()
        {
            CurrentGameInfo CGI = new CurrentGameInfo();

            CGI.Solution = GetSolution();
            CGI.PlayerSolution = new List<int>();
            CGI.KeyList = new List<string>();
            CGI.Tries = 10;

            return CGI;
        }

        private List<int> GetSolution()
        {
            GenerateSolution generateSolution = new GenerateSolution();
            return generateSolution.GenerateGameSolution();
        }
    }
}