using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.UI
{
    public class Messages
    {
        internal void PlayerEnter()
        {
            Console.WriteLine("Please Enter 1 - 6 ");
        }

        internal void PlayStart()
        {
            Console.WriteLine("Let's Play MasterMind!");
            Console.WriteLine("Press 'Enter' to start");
            Console.ReadLine();
            Console.Clear();
        }

        internal void EndPlay()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing");
            Console.WriteLine("Press 'Enter' to End");
            Console.ReadLine();
        }

        internal void InvalidMessage()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Invalid Number...");
            Console.ResetColor();
            Console.WriteLine();
        }

        internal void Win()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("CONGRATS YOU WON");
            Console.ResetColor();
            Console.WriteLine();
            AgainQuestion();
        }

        internal void TryAgain(int tries)
        {
            Console.WriteLine();
            Console.WriteLine("You have " + tries + " tries left");
            Console.WriteLine();
        }

        internal void Loser(List<int> solution)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("****You Loose****");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("The Correct Answer is...");
            WriteNumberList(solution);

            AgainQuestion();
        }

        internal void ClearConsole()
        {
            Console.Clear();
        }

        internal void WriteNumberList(List<int> playerSolution)
        {
            Console.Write("|");
            foreach (var num in playerSolution)
            {
                Console.Write(" " + num + " |");
            }
            Console.WriteLine("");
        }

        internal void ClearLine()
        {
            Console.WriteLine();
        }

        internal void WriteKeyList(List<string> keyList)
        {
            Console.Write("|");
            foreach (var key in keyList)
            {
                Console.Write(" " + key + " |");
            }
            Console.WriteLine("");
        }

        internal void AgainQuestion()
        {
            Console.WriteLine("");
            Console.WriteLine("Would you like to play again? Y/N");
            string input = Console.ReadLine();

            if (input.ToUpper() == "Y")
            {
                Console.Clear();
                GamePlay game = new GamePlay();
                game.StartNewGame();
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
    }
}
