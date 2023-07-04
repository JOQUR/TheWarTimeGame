using TheWarTimeGame.ConfigHandler;
using TheWarTimeGame.Items;
using TheWarTimeGame.Location;
using TheWarTimeGame.Mechanics;

namespace TheWarTimeGame.Menu;

public class LoadGame : ICommand
{
    private Library _lib;
    private Home _home;
    private Church _church;
    private HandleConfig cHandler;
    private Game game;
    public void Execute()
    {
        Console.WriteLine("Loading Game...");
    }
    public LoadGame(string filename)
    {
        InitLocations();
        Execute(filename);
        this.game = new Game(_home, _lib, _church);
    }
    public void Execute(string filename)
    {
        cHandler = new HandleConfig();
        _lib = (Library)cHandler.GetConfig(filename, _lib);
        _church = (Church)cHandler.GetConfig(filename, _church);
        _home = (Home)cHandler.GetConfig(filename, _home);
        _home.Loot.Add(new KeyValuePair<int, Items.ITem>(0, new Knife(KnifePerks.Standard, 2)));
    }

    private void InitLocations()
    {
        this._lib = new Library();
        this._church = new Church();
        this._home = new Home();
    }
}