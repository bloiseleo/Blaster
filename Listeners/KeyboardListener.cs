namespace Blaster.Listeners;

using Blaster.Actions;

internal class KeyboardListener : IListener
{
    private Game game;
    public KeyboardListener(Game game)
    {
        this.game = game;
    }
    public void Start()
    {
        while (true)
        {
            var info = Console.ReadKey();
            game.Push(new MoveCharacter(game, info.KeyChar));
        }
    }
}
