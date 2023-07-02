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
    public class Game
    {

        private Home _home;
        private Library _library;
        private Church _church;
        private Player _player;
        private InputHandler _inputHandler;
        private IExplore ExploreChurch, ExploreLib, StayHome;
        private int _days;
        public Game(Home home, Library library, Church church)
        {
            GameInit(home, library, church);
            do
            {
                InformUser();
                Explorer.Invoke(Action(_inputHandler.GetDecision()));
                Thread.Sleep(1000);
                _days++;
            } while (_days < 30);
        }

        public void GameInit(Home home, Library library, Church church)
        {
            _days = 0;
            _home = (Home)home.GetClone();
            _library = (Library)library.GetClone();
            _church = (Church)church.GetClone();
            _player = Player.GetPlayerInstance();
            _inputHandler = new InputHandler();
            ExploreChurch = new ExploreChurch();
            ExploreLib = new ExploreLibrary();
            StayHome = new StayHome();
        }

        private void InformUser()
        {
            Console.Clear();
            ConsoleOutput.ChangeConsoleColor(XMLparser.ReadScript("NewGame"), ConsoleColor.Magenta);
            ConsoleOutput.ChangeConsoleColor(MapParser.GetMap(), ConsoleColor.Gray);
        }

        private IExplore Action(int decision)
        {
            Console.Clear();
            switch (decision)
            {
                default:
                case 1:
                    return this.StayHome;
                case 2:
                    return this.ExploreLib;
                case 3:
                    return this.ExploreChurch;
            }
        }
    }
}
