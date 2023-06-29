using TheWarTimeGame.ConfigHandler;
using TheWarTimeGame.Items;
using TheWarTimeGame.Location;

namespace TheWarTimeGame.Mechanics
{
    internal class Game
    {
        readonly private Home _home;
        readonly private Library _library;
        readonly private Church _church;
        public Game()
        {
            GetConfig(ref _home);
            GetConfig(ref _library);
            GetConfig(ref _church);
            foreach (var kvp in _home.Loot.Select(kvp => kvp.Value))
            {
                Console.WriteLine("Name = {0}\nPrice = {1}", kvp.ToString(), kvp.Price);
            }

            Console.WriteLine("=============");
            foreach (var kvp in _library.Loot.Select(kvp => kvp.Value))
            {
                Console.WriteLine("Name = {0}\nPrice = {1}", kvp.ToString(), kvp.Price);
            }

            Console.WriteLine("=============");
            foreach (var kvp in _church.Loot.Select(kvp => kvp.Value))
            {
                Console.WriteLine("Name = {0}\nPrice = {1}", kvp.ToString(), kvp.Price);
            }
        }
        public void GetConfig(ref Home home)
        {
            home = new Home();
            XMLparser parser = new XMLparser(home);
        }
        public void GetConfig(ref Library library)
        {
            library = new Library();
            XMLparser parser = new XMLparser(library);
        }
        public void GetConfig(ref Church church)
        {
            church = new Church();
            XMLparser parser = new XMLparser(church);
        }
    }
}
