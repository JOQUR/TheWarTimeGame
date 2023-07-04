namespace TheWarTimeGame.Menu;

public class Quit : ICommand
{
    public void Execute()
    {
        Environment.Exit(0);
    }
    public void Execute(string filename)
    {
        Environment.Exit(0);
    }
}