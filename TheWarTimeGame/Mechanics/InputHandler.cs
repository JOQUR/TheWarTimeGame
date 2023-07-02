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
            int input = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            try
            {
                input = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                input = 0;
            }
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
    }
}
