namespace Blaster.Actions;

internal class MoveCharacter : IGameAction
{
    private Game game;
    private char key;

    public MoveCharacter(Game game, char key)
    {
        this.game = game;
        this.key = key;
    }
    public void Apply(Game game)
    {
        switch (key)
        {
            case 'd':
                int newY = game.Hero.Y + 1;
                game.MoveDrawable(game.Hero.X, newY, game.Hero);
                break;
            case 'a':
                newY = game.Hero.Y - 1;
                game.MoveDrawable(game.Hero.X, newY, game.Hero);
                break;
            case 'w':
                int newX = game.Hero.X - 1;
                game.MoveDrawable(newX, game.Hero.Y, game.Hero);
                break;
            case 's':
                newX = game.Hero.X + 1;
                game.MoveDrawable(newX, game.Hero.Y, game.Hero);
                break;
        }
    }
}
