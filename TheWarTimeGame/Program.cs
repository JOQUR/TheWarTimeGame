
using System.ComponentModel;
using Console = System.Console;
using Microsoft.Extensions.Logging.Console;
using System;
using TheWarTimeGame.Characters;
using TheWarTimeGame.ConfigHandler;
using TheWarTimeGame.Items;
using TheWarTimeGame.Menu;

namespace TheWarTimeGame
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            MainMenuHandler handler = new MainMenuHandler();
            handler.HandleDecision();
        }
    }
}