using TheWarTimeGame.Characters;
using TheWarTimeGame.ConfigHandler;

namespace TheWarTimeGame.Mechanics
{
    internal class QuickTimeEvent
    {
        public void HomeEvent()
        {
            string input = string.Empty;
            Thread thread = new Thread(() => clickButtons(input: ref input));
            thread.Start();
            Thread.Sleep(1000);
            if (input == string.Empty)
            {
                ConsoleManagment.Print("You Failed!\nPress Enter to continue...", ConsoleColor.Red);
                Thread.Sleep(500);
                Player.GetPlayerInstance().Health -= 2;
                return;
            }
            Player.GetPlayerInstance().Hunger++;

            ConsoleManagment.Print("\nYou did it!\nPress Enter to continue...", ConsoleColor.Green);
        }

        public void clickButtons(ref string input) => input = Console.ReadKey().ToString()!;

    }
}
