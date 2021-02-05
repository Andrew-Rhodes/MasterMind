using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public class GamePlay
    {
        internal void StartNewGame()
        {
            CurrentGameInfo CGI = new CurrentGameInfo();
            GetSolution(CGI);
            CGI.Tries = 10;

            while ( CGI.Tries > 0 )
            {
                PlayRound(CGI);
                CGI = CheckForWin(CGI);
            }
        }

        private CurrentGameInfo CheckForWin(CurrentGameInfo CGI)
        {
            bool result = CGI.PlayerSolution.SequenceEqual(CGI.Solution);

            if (result && CGI.Tries > 0)
            {
                Console.WriteLine("CONGRATS YOU WON");
                AgainQuestion();
                CGI.Tries = 0;
            }
            else if (!result && CGI.Tries > 1)
            {
                CGI.Tries--;
                Console.WriteLine();
                Console.WriteLine("You have " + CGI.Tries + " tries left");
                Console.WriteLine();
            }
            else if (CGI.Tries == 1)
            {
                Console.WriteLine();
                Console.WriteLine("****You Loose****");
                AgainQuestion();
                CGI.Tries = 0;
            }

            return CGI;
        }

        private void AgainQuestion()
        {
            Console.WriteLine("");
            Console.WriteLine("Would you like to play again? Y/N");
            string input = Console.ReadLine();

            if (input.ToUpper() == "Y")
            {
                Console.Clear();
                StartNewGame();
            }
            else if (input.ToUpper() == "N")
            {
                return;
            }
            else
            {
                AgainQuestion();
            }
        }

        private void GetSolution(CurrentGameInfo CGI)
        {
            GenerateSolution generateSolution = new GenerateSolution();
            CGI.Solution = generateSolution.GenerateGameSolution();

            CGI.PlayerSolution = new List<int>();
            CGI.KeyList = new List<string>();
        }

        private void PlayRound(CurrentGameInfo CGI)
        {
            GetPlayerKey(CGI);
            WriteList(CGI.PlayerSolution);
            Writekey(CGI.KeyList);
        }

        private void GetPlayerKey(CurrentGameInfo CGI)
        {
            CGI.PlayerSolution.Clear();
            CGI.KeyList.Clear();

            Console.WriteLine("");
            while (CGI.PlayerSolution.Count < 4)
            {
                PlayerInput(CGI);
            }

            CGI.KeyList = GenerateKeyList(CGI);
        }

        private List<string> GenerateKeyList(CurrentGameInfo CGI)
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

        private void WriteList(List<int> list)
        {
            Console.Write("|");
            foreach(var num in list)
            {
                Console.Write(" " + num + " |");
            }
            Console.WriteLine("");
        }

        private void Writekey(List<string> list)
        {
            Console.Write("|");
            foreach (var key in list)
            {
                Console.Write(" " + key + " |");
            }
            Console.WriteLine("");
        }

        private void PlayerInput(CurrentGameInfo CGI)
        {
            int playerGuess;
            Console.WriteLine("Enter 1 - 6 ");

            Int32.TryParse(Console.ReadLine(), out playerGuess);
            bool valid = validate(playerGuess);

            if (valid)
            {
                CGI.PlayerSolution.Add(playerGuess);
            }
            else
            {
                Console.WriteLine("Invalid Number...");
            }
        }

        private bool validate(int playerGuess)
        {
            bool result = playerGuess > 0 && playerGuess <= 6 ? true : false;
            return result;
        }
    }
}
