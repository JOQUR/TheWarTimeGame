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
    }
}
