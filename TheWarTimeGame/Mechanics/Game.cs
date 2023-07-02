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
        private double _hp;
        private int _hunger;
        public Game(Home home, Library library, Church church)
        {
            GameInit(home, library, church);
            do
            {
                _hp = Player.GetPlayerInstance().Health;
                _hunger = Player.GetPlayerInstance().Hunger;
                InformUser();
                Explorer.Invoke(Action(_inputHandler.GetDecision()));
                _days++;
                if(_hp <= 0 || _hunger <= 0)
                {
                    Environment.Exit(0);
                }
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
            StayHome = new StayHome(_home);
        }

        private void InformUser()
        {
            Console.Clear();
            ConsoleOutput.ChangeConsoleColor(XMLparser.ReadScript("NewGame"), ConsoleColor.Magenta);
            ConsoleOutput.ChangeConsoleColor("HP: " + _hp, ConsoleColor.DarkRed);
            ConsoleOutput.ChangeConsoleColor("Hunger: " + _hunger, ConsoleColor.DarkGreen);
            ConsoleOutput.ChangeConsoleColor(MapParser.GetMap(), ConsoleColor.Gray);
        }

        private IExplore Action(int decision)
        {
            Console.Clear();
            switch (decision)
            {
                default:
                case 1:
                {
                    ConsoleOutput.ChangeConsoleColor("You decided to stay home!", ConsoleColor.Yellow, true);
                    return this.StayHome;
                } 
                case 2:
                {
                    ConsoleOutput.ChangeConsoleColor("You decided to explore library!", ConsoleColor.Yellow, true);
                    return this.ExploreLib;
                }
                case 3:
                {
                    ConsoleOutput.ChangeConsoleColor("You decided to explore church!", ConsoleColor.Yellow, true);
                    return this.ExploreChurch;
                }
            }
        }
    }
}
