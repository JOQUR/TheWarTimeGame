using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Mechanics;

namespace TheWarTimeGame.Menu
{
    public class NewGame : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Starting New Game");
            Game game = new Game();
        }
    }
}
