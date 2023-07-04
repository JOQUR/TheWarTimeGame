using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.ConfigHandler;

namespace TheWarTimeGame.Mechanics
{
    internal class Finish
    {
        public Finish()
        {
            Console.Clear();
            ConsoleManagment.Print(XMLparser.ReadScript("Finish"), ConsoleColor.Cyan, true);
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
