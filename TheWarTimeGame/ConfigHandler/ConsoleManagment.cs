using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;

namespace TheWarTimeGame.ConfigHandler
{
    public static class ConsoleManagment
    {
        public static void Print(string text,  ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Print(string text, ConsoleColor color, bool clearTerminal)
        {
            if(clearTerminal)
                Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static bool ReadDecision(ConsoleKeyInfo keyInfo)
        {
            if(keyInfo.Key == ConsoleKey.Y)
            {
                return true;
            }
            return false;
        }
        public static void GetStats(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.H:
                    Print("HP: " + Player.GetPlayerInstance().Health, ConsoleColor.Green, true);
                    break;
                case ConsoleKey.J:
                    Print("Hunger: " + Player.GetPlayerInstance().Hunger, ConsoleColor.Green, true);
                    break;
                case ConsoleKey.E:
                {
                    Print("Item List Below: ", ConsoleColor.Green, true);
                    foreach(var i in Player.GetPlayerInstance().Equipment)
                    {
                            Print(i.ToString()!, ConsoleColor.Green);
                    }
                    break;
                }
            }
        }
    }
}
