
using System.ComponentModel;
using Console = System.Console;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.DependencyInjection;
using System;
using TheWarTimeGame.Items;
using TheWarTimeGame.Menu;

namespace TheWarTimeGame
{
    internal static class Program
    {
        static void Main(string[] args)
        {

            SomeMethod();
        }

        public static void SomeMethod()
        {
            double health = 10.0;
            Pistol pistol = new Pistol();
            pistol.Attack(ref health);
            Console.WriteLine(health);
            Thread newThread = new Thread(() => { pistol.Bleeding(ref health);});
            newThread.Start();
            Thread.Sleep(1000);
            Console.WriteLine(Math.Round(health, 2));
        }
    }

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
                    builder.SetMinimumLevel(LogLevel.Debug);
                    builder.AddConsole();
                })
                .BuildServiceProvider();
            _logger = serviceProvider.GetService<ILoggerFactory>()!.CreateLogger<MainMenuHandler>();
        }

        public void HandleDecision()
        {
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
}