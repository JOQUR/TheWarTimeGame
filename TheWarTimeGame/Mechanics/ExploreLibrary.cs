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
        private Fight fight;
        IWeapon _weapon;
        public ExploreLibrary(Library lib)
        {
            this._lib = lib;
        }
        public void Explore(IWeapon weapon)
        {
            seenByEnemies();
            if (_seenByEnemies)
            {
                Player.GetPlayerInstance().Weapon = weapon;
                fight = new Fight(_lib.GetClone());
            }

            Console.ReadKey();
            ConsoleManagment.Print("Explore Library", ConsoleColor.Yellow, true);
            Console.ReadKey();
            loot();

        }

        private void seenByEnemies()
        {
            rnd = new Random();
            if (rnd.Next(10) < 6)
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
            Player.GetPlayerInstance().Hunger -= 2;
            if (_lib.Loot.Count == 0)
            {
                ConsoleManagment.Print("Location is empty!", ConsoleColor.Yellow, true);
                Console.ReadKey();
                return;
            }
            int index = rnd.Next(0, _lib.Loot.Count - 1);
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
