using Blaster.Actions;
using Blaster.sprites;
using Blaster.ui;

namespace Blaster;

internal class Game
{
    private Map map;
    public Hero Hero;
    private bool needRewrite = false;
    public List<IGameAction> gameActions = new();
    public Game() {
        map = new Map(25, 100);
    }
    public void ClearMap()
    {
        map.Clear();
    }
    public void ExecuteActions()
    {
        if(gameActions.Count > 0)
        {
            gameActions.ForEach(action => action.Apply(this));
            gameActions.Clear();
        }
        if(needRewrite)
        {
            Console.Clear();
            Console.WriteLine(this);
            needRewrite  = false;
        }
    }
    public void MoveDrawable(int toX, int toY, Drawable obj)
    {
        if (toX >= map.Lines || toY >= map.Columns || toX < 0 || toY < 0)
        {
            return;
        }
        int oldX = obj.X;
        int oldY = obj.Y;
        obj.X = toX;
        obj.Y = toY;
        if (obj.Width >= map.Columns || obj.Height >= map.Lines)
        {
            obj.X = oldX;
            obj.Y = oldY;
            return;
        }
        map.Replace(obj, oldX, oldY);
        needRewrite = true;
    }
    public void start()
    {
        Hero = new Hero(0, 0);
        Hero.X = map.Lines - Hero.Height - 1;
        Hero.Y =  map.Columns - (Hero.Width);
        map.Draw(Hero);
        Console.WriteLine(this);
    }
    public void Push(IGameAction action)
    {
        gameActions.Add(action);
    }
    public override string ToString()
    {
        return map.ToString();
    }
}
