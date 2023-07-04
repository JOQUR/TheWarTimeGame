namespace TheWarTimeGame.Menu;

public interface ICommand
{
    void Execute();
    void Execute(string filename);
}   