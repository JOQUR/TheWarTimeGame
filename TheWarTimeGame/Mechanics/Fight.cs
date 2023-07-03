using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;
using TheWarTimeGame.ConfigHandler;
using TheWarTimeGame.Location;

namespace TheWarTimeGame.Mechanics
{
    internal class Fight
    {
        private Player _player;
        private ILocation _location;
        private Enemy enemy;
        public Fight(ILocation location) 
        {
            _player = Player.GetPlayerInstance();
            _location = location;
            enemy = (Enemy)_location.Enemies.First().Value;
            battle();
            showBattleStats();
        }

        private void battle()
        {
            double enHP = enemy.Health;
            double playerHP = _player.Health;
            while (true)
            {
                _player.Weapon.Attack(ref enHP);
                enemy.Attack(ref playerHP);
                if (enHP <= 0)
                { break; }
                if(playerHP <= 0)
                {
                    ConsoleManagment.Print("GAME OVER!", ConsoleColor.Red);
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            _player.Health = playerHP;
        }

        private void showBattleStats()
        {
            ConsoleManagment.Print("Your hp left: " + _player.Health, ConsoleColor.Green, true);
            Console.ReadKey();
        }



    }
}
