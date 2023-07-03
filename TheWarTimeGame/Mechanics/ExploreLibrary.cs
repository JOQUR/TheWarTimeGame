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
    internal class ExploreLibrary : IExplore
    {
        private bool _seenByEnemies;
        private Random rnd;
        private Library _lib;
        public ExploreLibrary(Library lib)
        {
            this._lib = lib;
        }
        public void Explore()
        {
            seenByEnemies();
            ConsoleManagment.Print("Explore Library", ConsoleColor.Yellow, true);
            Console.ReadKey();
            loot();
        }

        private void seenByEnemies()
        {
            rnd = new Random();
            if (rnd.Next(10) < 4)
            {
                _seenByEnemies = true;
            }
            else
            {
                _seenByEnemies = false;
            }
        }
        private void loot()
        {
            int index = rnd.Next(_lib.Loot.Count);
            KeyValuePair<int, ITem> item = new KeyValuePair<int, ITem>();
            item = _lib.Loot[index];
            ConsoleManagment.Print("You found: " + item.Value, ConsoleColor.Yellow, true);
            ConsoleManagment.Print("Do You wish to take it?(y/n)", ConsoleColor.Yellow);
            bool decision = ConsoleManagment.ReadDecision(Console.ReadKey());

            if (decision) 
            {
                _lib.Loot.RemoveAt(index);
                Player.GetPlayerInstance().Equipment.Add(item.Value);
            }
        }
    }
}
