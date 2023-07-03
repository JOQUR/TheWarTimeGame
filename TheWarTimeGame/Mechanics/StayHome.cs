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

        public void Explore(IWeapon weapon)
        {
            ConsoleManagment.Print(XMLparser.ReadScript("StayHome"), ConsoleColor.DarkYellow);
            Player.GetPlayerInstance().Health++;
            if ((Player.GetPlayerInstance().Health) > 10)
            {
                Player.GetPlayerInstance().Health = 10;
            }
            useItem(Player.GetPlayerInstance().Equipment);
            Player.GetPlayerInstance().Hunger -= 1;
            ConsoleManagment.Print(XMLparser.ReadScript("QuickEvent"), ConsoleColor.Green);
            Console.ReadLine();

            SpecialEvent();
        }

        private void useItem(List<ITem> list)
        {
            InputHandler handler = new InputHandler();
            ConsoleManagment.Print("Would you mind to use any item? (y/n)", ConsoleColor.Cyan);
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (!readKey(key))
                return;

            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0}) {1}", (i + 1), list[i].ToString());
            }
            ConsoleManagment.Print("Which one?", ConsoleColor.Cyan);
            int index = handler.GetDecision();
            while(!(index <= (Player.GetPlayerInstance().Equipment.Count) && index >= 1))
            {
                ConsoleManagment.Print("Wrong INPUT!", ConsoleColor.Red);
                index = handler.GetDecision();
            }
            if (list[index - 1].GetType() == typeof(Knife) || list[index - 1].GetType() == typeof(Pistol))
            {
                return;
            }
            double x = 1.0; // Unused but necessary
            list[index - 1].Use(ref x);
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
