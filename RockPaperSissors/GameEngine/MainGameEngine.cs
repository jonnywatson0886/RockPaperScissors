using RockPaperSissors.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperSissors.GameEngine
{
    public class MainGameEngine
    {
        private int turn;
        private BasePlayer _player1;
        private BasePlayer _player2;
        private int winningScore;
        private bool gameWon;
        public MainGameEngine(BasePlayer player, BasePlayer player2)
        {
            winningScore = 5;
            turn = 0;
            _player1 = player;
            _player2 = player2;
            gameWon = false;
        }

        public void PlayGame()
        {
            while (!gameWon)
            {
                PlayRound();
            }
        }

        private void PrintScores()
        {
            Console.WriteLine($"scores after round {turn} \n");
            _player1.PrintScore();
            _player2.PrintScore();
            Console.WriteLine($"\nhit any key to continue\n");
            Console.ReadKey();
            Console.Clear();
        }

        private void PlayRound()
        {
            _player1.MakeMove();
            _player2.MakeMove();

            var winner = FindRoundWinner();

            if (winner != null)
            {
                winner.WinRound();
                if (winner.CheckForWin(winningScore))
                {
                    Console.WriteLine($"We have a winner player {winner.Name} won with a score of {winningScore} on turn {turn}");
                    gameWon = true;
                    return;
                }
            }
            turn++;
            PrintScores();
        }

        private BasePlayer FindRoundWinner()
        {
            if (_player1.SelectedChoice != _player2.SelectedChoice)
            {
                switch (_player1.SelectedChoice)
                {
                    case GameChoices.Rock:
                        if (_player2.SelectedChoice == GameChoices.Paper)
                        {
                            return _player2;
                        }
                        return _player1;

                    case GameChoices.Paper:
                        if (_player2.SelectedChoice == GameChoices.Scissors)
                        {
                            return _player2;
                        }
                        return _player1;

                    case GameChoices.Scissors:
                        if (_player2.SelectedChoice == GameChoices.Rock)
                        {
                            return _player2;
                        }
                        return _player1;

                    default: throw new Exception("Unexpected values in round");
                }
            }
            Console.WriteLine("round draw");
            return null;
        }
    }
}
