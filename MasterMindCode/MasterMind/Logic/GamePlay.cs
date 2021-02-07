using MasterMind.Logic;
using MasterMind.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public class GamePlay
    {
        ModelBuilder _modelBuilder = new ModelBuilder();
        Messages _ui = new Messages();
        GameLogic _gameLogic = new GameLogic();

        internal void StartNewGame()
        {
            CurrentGameInfo CGI = _modelBuilder.GetStartModel();

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
                _ui.Win();
                CGI.Tries = 0;
            }
            else if (!result && CGI.Tries > 1)
            {
                CGI.Tries--;
                _ui.TryAgain(CGI.Tries);

            }
            else if (CGI.Tries == 1)
            {
                _ui.Loser(CGI.Solution);
                CGI.Tries = 0;
            }

            return CGI;
        }

        private void PlayRound(CurrentGameInfo CGI)
        {
            GetPlayerKey(CGI);
            _ui.ClearConsole();
            _ui.WriteNumberList(CGI.PlayerSolution);
            _ui.WriteKeyList(CGI.KeyList);
        }

        private void GetPlayerKey(CurrentGameInfo CGI)
        {
            CGI.PlayerSolution.Clear();
            CGI.KeyList.Clear();
            
            while (CGI.PlayerSolution.Count < 4)
            {
                PlayerInput(CGI);
            }

            CGI.KeyList = _gameLogic.GenerateKeyList(CGI);
        }

        private void PlayerInput(CurrentGameInfo CGI)
        {
            int playerGuess;
            _ui.PlayerEnter();
            
            Int32.TryParse(Console.ReadLine(), out playerGuess);
            bool valid = _gameLogic.Validate(playerGuess);

            if (valid)
            {
                _ui.ClearLine();
                CGI.PlayerSolution.Add(playerGuess);
            }
            else
            {
                _ui.InvalidMessage();
            }
        }
    }
}