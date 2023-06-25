
using System.ComponentModel;
using Console = System.Console;
using Microsoft.Extensions.Logging.Console;
using System;
using TheWarTimeGame.Characters;
using TheWarTimeGame.ConfigHandler;
using TheWarTimeGame.Items;

namespace TheWarTimeGame
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            new XMLparser();
            //SomeMethod();
        }

        public static void SomeMethod()
        {
            Player player = Player.GetPlayerInstance();
            double health = player.Health;
            Enemy enemy = new Enemy
            {
                Health = 12
            };
            Pistol pistol = new Pistol();
            player.Attack(ref enemy);
            player.Weapon = pistol;
            player.Attack(ref enemy);
            new Thread(() => { pistol.Bleeding(ref enemy); }).Start();
            Console.WriteLine(enemy.Health);
        }
    }
}