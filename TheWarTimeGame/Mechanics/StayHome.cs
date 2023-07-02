using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;
using TheWarTimeGame.ConfigHandler;
using TheWarTimeGame.Items;
using TheWarTimeGame.Location;

namespace TheWarTimeGame.Mechanics
{
    public class StayHome : IExplore
    {
        private Home _home;

        public StayHome(Home home)
        {
            _home = (Home)home.GetClone();
        }

        public void Explore()
        {
            ConsoleOutput.ChangeConsoleColor(XMLparser.ReadScript("QuickEvent"), ConsoleColor.Green);
            Console.ReadLine();
            QuickTimeEvent.HomeEvent();
            ConsoleOutput.ChangeConsoleColor(XMLparser.ReadScript("StayHome"), ConsoleColor.DarkYellow);
            if((Player.GetPlayerInstance().Hunger--) < 0)
            {
                Console.WriteLine("YOU LOSE");
            }
            if ((Player.GetPlayerInstance().Health++) > 10)
            {
                Player.GetPlayerInstance().Health = 10;
            }
            useItem(_home.Loot);
        }

        private void useItem(List<KeyValuePair<int, ITem>> list)
        {
            InputHandler handler = new InputHandler();
            ConsoleOutput.ChangeConsoleColor("Would you mind to use any item?", ConsoleColor.Cyan);
            bool x = Convert.ToBoolean(handler.GetDecision());
            if (!x)
            {
                return;
            }
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0}) {1}", (i + 1), list[i].Value);
            }
            ConsoleOutput.ChangeConsoleColor("Which one?", ConsoleColor.Cyan);
            again:
            int index = handler.GetDecision();
            if(index > 3 || index < 1)
            {
                ConsoleOutput.ChangeConsoleColor("Wrong Input", ConsoleColor.Red);
                goto again;
            }
            list[index - 1].Value.Use();
            if (list[index - 1].Value.GetType() == typeof(Knife) || list[index - 1].Value.GetType() == typeof(Pistol))
            {
                return;
            }

            list.RemoveAt(index - 1);
        }
    }
}
