using RockPaperSissors.GameEngine;
using RockPaperSissors.Player;
using System;

namespace RockPaperSissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to rock paper sissors pc mrk1");
            var startGame = true;
            while (startGame)
            {
                var game = SetupGame();
                game.PlayGame();

                Console.WriteLine("if you want to start a new game hit 1\n");
                var consoleInput = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();

                int input;
                if (!int.TryParse(consoleInput,out input) || input != 1)
                {
                    startGame = false;
                }
            }
        }

        private static MainGameEngine SetupGame()
        {
            BasePlayer player1;
            BasePlayer player2;
            var playMode = GetMode();
            if (playMode == 2)
            {
                Console.WriteLine("Please Enter Player 1 name \n");
                player1 = new HumanPlayer(Console.ReadLine());

                Console.WriteLine("Please Enter Player 2 name \n");
                player2 = new HumanPlayer(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Please Enter your name \n");
                player1 = new HumanPlayer(Console.ReadLine());
                player2 = new AIPlayer();
            }
            return new MainGameEngine(player1, player2);
        }

        private static int GetMode()
        {
            var retryMessage = "input not valid please enter 1 or 2 \n";
            while (true)
            {
                Console.WriteLine("\nHow many players 1 or 2 ?");
                var input = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                int inputInt;
                if (int.TryParse(input, out inputInt))
                {
                    if (inputInt > 0 && inputInt < 3)
                    {
                        return inputInt;
                    }
                }
                Console.Clear();
                Console.WriteLine(retryMessage);
            }
        }
    }
}


