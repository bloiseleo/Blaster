namespace Blaster.ui;

internal abstract class Drawable
{
    protected int x;
    protected int y;
    public int X { get; }
    public int Y { get; }
    public char[,] Sprite;
    public int Width { get => Sprite.GetLength(1); }
    public int Height { get => Sprite.GetLength(0); }
    public Drawable(int x, int y)
    {
        this.x = x;
        this.y = y;
        Sprite = loadSprite();
    }
    protected abstract char[,] loadSprite();
}
