using TheWarTimeGame.ConfigHandler;
using TheWarTimeGame.Location;

namespace TheWarTimeGame.Mechanics
{
    internal class Game
    {
        private Home _home;
        private Library _library;
        public Game()
        {
            GetConfig(ref _home);
            GetConfig(ref _library);
            foreach (var kvp in _home.Loot.Select(kvp => kvp.Value))
            {
                Console.WriteLine("Name = {0}\nPrice = {1}", kvp.ToString(), kvp.Price);
            }

            Console.WriteLine("=============");
            foreach (var kvp in _library.Loot.Select(kvp => kvp.Value))
            {
                Console.WriteLine("Name = {0}\nPrice = {1}", kvp.ToString(), kvp.Price);
            }
        }
        public void GetConfig(ref Home home)
        {
            home = new Home();
            XMLparser parser = new XMLparser(home);
        }
        public void GetConfig(ref Library lib)
        {
            lib = new Library();
            XMLparser parser = new XMLparser(lib);
        }
    }
}
