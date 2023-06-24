using TheWarTimeGame.Menu;

namespace TheWarTimeGame.Menu;

public class Invoker
{
    protected Invoker(){}
    public static void Invoke(ICommand command)
    {
        command.Execute();
    }
}