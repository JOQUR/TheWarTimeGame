using TheWarTimeGame.Characters;
using TheWarTimeGame.ConfigHandler;
using TheWarTimeGame.Items;
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
        private double _hunger;
        private IWeapon _choosenWeapon;
        public Game(Home home, Library library, Church church)
        {
            GameInit(home, library, church);
            do
            {
                updateHomeShelfs();
                _hp = Player.GetPlayerInstance().Health;
                _hunger = Player.GetPlayerInstance().Hunger;
                InformUser();
                Explorer.Invoke(Action(_inputHandler.GetDecision()), _choosenWeapon);
                _days++;
                if(Player.GetPlayerInstance().Health <= 0 || Player.GetPlayerInstance().Hunger <= 0)
                {
                    ConsoleManagment.Print("YOU LOST!", ConsoleColor.Red, true);
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
            ExploreChurch = new ExploreChurch((Church)church.GetClone());
            ExploreLib = new ExploreLibrary((Library)library.GetClone());
            StayHome = new StayHome(_home);
            
        }

        private void InformUser()
        {
            Console.Clear();
            ConsoleManagment.Print(XMLparser.ReadScript("Instruction"), ConsoleColor.Magenta);
            ConsoleManagment.GetStats(Console.ReadKey(), (Home)_home.GetClone(), (Library)_library.GetClone(), (Church)_church.GetClone());
            ConsoleManagment.Print(XMLparser.ReadScript("NewGame"), ConsoleColor.White);
            ConsoleManagment.Print(MapParser.GetMap(), ConsoleColor.Gray);
        }

        private void updateHomeShelfs()
        {
            for(int i = 0; i < _home.Loot.Count; i++)
            {
                Player.GetPlayerInstance().Equipment.Add(_home.Loot[i].Value);
                _home.Loot.RemoveAt(i);
            }
        }

        private IExplore Action(int decision)
        {
            
            string choice = string.Empty;
            Console.Clear();
            switch (decision)
            {
                default:
                case 1:
                {
                    ConsoleManagment.Print("You decided to stay home!", ConsoleColor.Yellow, true);
                    return this.StayHome;
                } 
                case 2:
                {
                    ConsoleManagment.Print("You decided to explore library!", ConsoleColor.Yellow, true);
                    setWeapon(choice);
                    return this.ExploreLib;
                }
                case 3:
                {
                    ConsoleManagment.Print("You decided to explore church!", ConsoleColor.Yellow, true);
                    setWeapon(choice);
                    return this.ExploreChurch;
                }
            }
        }

        private void setWeapon(string choice)
        {
            ConsoleManagment.Print("You need to choose weapon which you will use durign exploration. (p-pistol/k-knife)", ConsoleColor.Green);
            _choosenWeapon = null;
            while (_choosenWeapon == null)
            {
                choice = ConsoleManagment.ChooseWeapon(Console.ReadKey(true));
                if (choice == "Knife")
                {
                    _choosenWeapon = (Knife)Player.GetPlayerInstance().Equipment.Find(x => x.ToString() == choice);
                }
                else if (choice == "Pistol")
                {
                    _choosenWeapon = (Pistol)Player.GetPlayerInstance().Equipment.Find(x => x.ToString() == choice);
                }
                if (null == _choosenWeapon)
                {
                    ConsoleManagment.Print("You don't have this item!", ConsoleColor.Red);
                }
            }
        }
    }
}
