
using System.ComponentModel;
using Console = System.Console;
using Microsoft.Extensions.Logging.Console;
using System;
using TheWarTimeGame.Characters;
using TheWarTimeGame.Items;

namespace TheWarTimeGame
{
    internal static class Program
    {
        static void Main(string[] args)
        {

            SomeMethod();
        }

        public static void SomeMethod()
        {
            Player player = Player.GetPlayerInstance();
            double health = player.Health;
            Enemy enemy = new Enemy();
            enemy.Health = health;
            Pistol pistol = new Pistol();
            player.Attack(ref enemy);
            Console.WriteLine(health);
            Console.WriteLine(Math.Round(health, 2));
        }
    }
}