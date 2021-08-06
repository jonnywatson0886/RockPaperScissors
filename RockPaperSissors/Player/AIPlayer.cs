using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperSissors.Player
{
    public class AIPlayer : BasePlayer
    {
        public AIPlayer() : base() => Name = "Bot";
        public override void MakeMove()
        {
            Random rnd = new Random();
            var selection = rnd.Next(1,3);
            SelectedChoice = (GameChoices)Enum.Parse(typeof(GameChoices), selection.ToString());
        }
    }
}
