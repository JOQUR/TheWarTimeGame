using TheWarTimeGame.Items;
using TheWarTimeGame.Location;

namespace TheWarTimeGame.ConfigHandler
{
    internal class HandleConfig
    {
        public HandleConfig()
        {
        }
        public ILocation GetConfig(Home home)
        {
            home = new Home();
            _ = new XMLparser(home);
            return home;
        }
        public ILocation GetConfig(Library library)
        {
            _ = new XMLparser(library);
            return library;
        }
        public ILocation GetConfig(Church church)
        {
            church = new Church();
            _ = new XMLparser(church);
            return church;
        }

        public ILocation GetConfig(string filename, Home home)
        {
            home = new Home();
            _ = new XMLparser(filename, home);
            return home;
        }
        public ILocation GetConfig(string filename, Library library)
        {
            _ = new XMLparser(filename, library);
            return library;
        }
        public ILocation GetConfig(string filename, Church church)
        {
            church = new Church();
            _ = new XMLparser(filename, church);
            return church;
        }
    }
}
