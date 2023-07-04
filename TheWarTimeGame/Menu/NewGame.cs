using TheWarTimeGame.ConfigHandler;
using TheWarTimeGame.Location;
using TheWarTimeGame.Mechanics;

namespace TheWarTimeGame.Menu
{
    public class NewGame : ICommand
    {
        private Library _lib;
        private Home _home;
        private Church _church;
        private HandleConfig cHandler;
        private Game game;
        public void Execute()
        {
            cHandler = new HandleConfig();
            _lib = (Library)cHandler.GetConfig(_lib);
            _church = (Church)cHandler.GetConfig(_church);
            _home = (Home)cHandler.GetConfig(_home);
        }


        public void Execute(string filename)
        {
            cHandler = new HandleConfig();
            _lib = (Library)cHandler.GetConfig(filename, _lib);
            _church = (Church)cHandler.GetConfig(filename, _church);
            _home = (Home)cHandler.GetConfig(filename, _home);
        }

        public NewGame()
        {
            InitLocations();
            Execute();
            this.game = new Game(_home, _lib, _church);
            
        }

        private void InitLocations()
        {
            this._lib = new Library();
            this._church = new Church();
            this._home = new Home();
        }
    }
}
