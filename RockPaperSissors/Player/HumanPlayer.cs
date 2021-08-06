using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperSissors.Player
{
    public class HumanPlayer : BasePlayer
    {
        public HumanPlayer(string name): base() => Name = name;

        public override void MakeMove()
        {
            Console.Clear();
            Console.WriteLine($"Player {Name} its is your turn please hit a key when ready\n");
            Console.ReadKey();
            SelectedChoice = GetPlayerSelection();
            Console.Clear();
        }

        private GameChoices GetPlayerSelection()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter your choice:\n" +
                    "1- rock\n" +
                    "2- paper\n" +
                    "3- scissors");

                    var consoleInput = Console.ReadKey().KeyChar.ToString();
                    Console.WriteLine();

                    int input;
                    if (!int.TryParse(consoleInput, out input))
                    {
                        throw new Exception("input not vaild input");
                    }
                    switch (input)
                    {
                        case (1): return GameChoices.Rock;
                        case (2): return GameChoices.Paper;
                        case (3): return GameChoices.Scissors;
                        default: throw new Exception("input not vaild number");
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Not a Vaild Choice");
                    continue;
                }
            }
        }
    }
}
