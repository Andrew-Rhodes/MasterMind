using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Logic
{
    public class GameLogic
    {
        internal bool Validate(int playerGuess)
        {
            bool result = playerGuess > 0 && playerGuess <= 6 ? true : false;
            return result;
        }

        internal List<string> GenerateKeyList(CurrentGameInfo CGI)
        {
            string SymbolToAdd;

            for (var x = 0; x < CGI.PlayerSolution.Count; x++)
            {
                if (CGI.Solution.Any(y => y.Equals(CGI.PlayerSolution[x])))
                {
                    SymbolToAdd = "-";

                    if (CGI.PlayerSolution[x] == CGI.Solution[x])
                    {
                        SymbolToAdd = "+";
                    }
                }
                else
                {
                    SymbolToAdd = " ";
                }

                CGI.KeyList.Add(SymbolToAdd);
            }

            return CGI.KeyList;
        }
    }
}
