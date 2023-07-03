using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheWarTimeGame.ConfigHandler;

namespace TheWarTimeGame.Menu;

public class MainMenuHandler
{
    private ICommand? _command;
    private readonly ILogger _logger;
    public MainMenuHandler()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Critical);
                builder.AddConsole();
            })
            .BuildServiceProvider();
        _logger = serviceProvider.GetService<ILoggerFactory>()!.CreateLogger<MainMenuHandler>();
    }

    public void HandleDecision()
    {
        ConsoleManagment.Print(XMLparser.ReadScript("Invitation"), ConsoleColor.DarkBlue);
        int decision = GetDecision();
        switch (decision)
        {
            case 1:
                _command = new NewGame();
                break;
            case 2:
                _command = new LoadGame();
                break;
            case 3:
                _command = new Quit();
                break;

            default:
                _command = new Quit();
                break;
        }

        Invoker.Invoke(_command);
    }
    private int GetDecision()
    {
        int decision = 0;
        bool isCorrect;
        do
        {
            try
            {
                isCorrect = true;
                decision = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException e)
            {
                _logger.LogError(e.ToString() +
                                 "\n==============================================================\nIt must be a number");
                isCorrect = false;
            }
        } while (!isCorrect);
        return decision;
    }
}