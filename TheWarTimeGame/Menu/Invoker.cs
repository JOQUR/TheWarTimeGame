using TheWarTimeGame.Menu;

namespace TheWarTimeGame.Menu;

public class Invoker
{
    protected Invoker(){}
    public static void Invoke(ICommand command)
    {
        command.Execute();
    }

    public static void Invoke(ICommand command, string filename)
    {
        command.Execute(filename);
    }

}