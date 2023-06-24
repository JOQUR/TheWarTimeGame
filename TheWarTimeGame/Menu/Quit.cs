namespace TheWarTimeGame.Menu;

public class Quit : ICommand
{
    public void Execute()
    {
        Environment.Exit(0);
    }
}