using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWarTimeGame.Mechanics
{
    internal class InputHandler
    {
        public int GetDecision()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int input = Int32.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
    }
}
