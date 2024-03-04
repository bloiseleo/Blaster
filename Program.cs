namespace Blaster;

using Blaster.Listeners;

internal class Program
{
    static Game game;
    private static void startListener()
    {
        var keyboardThread = new Thread(new KeyboardListener(game).Start);
        keyboardThread.Start();
    }
    static void Main(string[] args)
    {
        game = new Game();
        startListener();
        game.start();
        while(true)
        {
            game.ExecuteActions();
            Thread.Sleep(100);
        }
    }
}
