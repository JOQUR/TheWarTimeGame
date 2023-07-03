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
            ConsoleManagment.Print(XMLparser.ReadScript("StayHome"), ConsoleColor.DarkYellow);
            Player.GetPlayerInstance().Health++;
            if ((Player.GetPlayerInstance().Hunger--) < 0 || Player.GetPlayerInstance().Health <= 0)
            {
                Console.WriteLine("YOU LOSE!");
            }
            if ((Player.GetPlayerInstance().Health) > 10)
            {
                Player.GetPlayerInstance().Health = 10;
            }
            useItem(_home.Loot);

            ConsoleManagment.Print(XMLparser.ReadScript("QuickEvent"), ConsoleColor.Green);
            Console.ReadLine();

            SpecialEvent();
        }

        private void useItem(List<KeyValuePair<int, ITem>> list)
        {
            InputHandler handler = new InputHandler();
            ConsoleManagment.Print("Would you mind to use any item? (y/n)", ConsoleColor.Cyan);
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (!readKey(key))
                return;

            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0}) {1}", (i + 1), list[i].Value);
            }
            ConsoleManagment.Print("Which one?", ConsoleColor.Cyan);
            int index = handler.GetDecision();
            while(!(index <= 3 && index >= 1))
            {
                ConsoleManagment.Print("Wrong INPUT!", ConsoleColor.Red);
                index = handler.GetDecision();
            }
            list[index - 1].Value.Use();
            if (list[index - 1].Value.GetType() == typeof(Knife) || list[index - 1].Value.GetType() == typeof(Pistol))
            {
                return;
            }

            list.RemoveAt(index - 1);
        }

        private void SpecialEvent()
        {
            QuickTimeEvent quickTimeEvent = new QuickTimeEvent();
            quickTimeEvent.HomeEvent();
            Console.ReadLine();
        }
        private bool readKey(ConsoleKeyInfo key)
        {
            bool ret = false;
            if(key.Key == ConsoleKey.N)
            {
                ret = false;
            }
            else if(key.Key == ConsoleKey.Y)
            {
                ret = true;
            }

            return ret;
        }
    }
}
