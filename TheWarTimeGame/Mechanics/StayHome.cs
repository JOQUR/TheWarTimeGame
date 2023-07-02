using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;
using TheWarTimeGame.ConfigHandler;

namespace TheWarTimeGame.Mechanics
{
    public class StayHome : IExplore
    {
        Player player;
        public void Explore()
        {
            ConsoleOutput.ChangeConsoleColor(XMLparser.ReadScript("StayHome"), ConsoleColor.DarkYellow);
            if((Player.GetPlayerInstance().Hunger--) < 0)
            {
                Console.WriteLine("YOU LOSE");
            }
            if ((Player.GetPlayerInstance().Health++) > 10)
            {
                Player.GetPlayerInstance().Health = 10;
            }
        }
    }
}
