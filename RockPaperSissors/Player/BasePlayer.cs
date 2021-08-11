using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperSissors.Player
{
    public abstract class BasePlayer
    {
        public string Name;
        public int Score;
        public GameChoices SelectedChoice;

        public BasePlayer()
        {
            Score = 0;
            SelectedChoice = GameChoices.None;
        }

        public abstract void MakeMove();

        public void WinRound()
        {
            Console.WriteLine($"player {Name} won round with {SelectedChoice.ToString()}");
            Score++;
        }


        public void PrintScore()
        {
            Console.WriteLine($"player {Name} score is: {Score}");
        }

        public bool CheckForWin(int target)
        {
            if (Score >= target)
            {
                return true;
            }
            return false;
        }
    }
}
