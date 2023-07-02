using TheWarTimeGame.Characters;
using TheWarTimeGame.ConfigHandler;

namespace TheWarTimeGame.Mechanics
{
    internal static class QuickTimeEvent
    {
        public static void HomeEvent()
        {
            string input = string.Empty;
            Thread thread = new Thread(() => clickButtons(input: ref input));
            thread.Start();
            Thread.Sleep(1000);
            if (input == string.Empty)
            {
                ConsoleOutput.ChangeConsoleColor("You Failed!", ConsoleColor.Red);
                Thread.Sleep(500);
                Player.GetPlayerInstance().Health--;
                return;
            }
            Player.GetPlayerInstance().Hunger++;
            Thread.Sleep(500);
            ConsoleOutput.ChangeConsoleColor("You did it!", ConsoleColor.Green);
        }

        public static void clickButtons(ref string input) => input = Console.ReadLine();
    }
}
