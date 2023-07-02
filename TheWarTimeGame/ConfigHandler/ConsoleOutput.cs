using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TheWarTimeGame.ConfigHandler
{
    public static class ConsoleOutput
    {
        public static void ChangeConsoleColor(string text,  ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void ChangeConsoleColor(string text, ConsoleColor color, bool clearTerminal)
        {
            if(clearTerminal)
                Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
