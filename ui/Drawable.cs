namespace Blaster.ui;

internal abstract class Drawable
{
    protected int x;
    protected int y;
    public int X { get; set; }
    public int Y { get; set; }
    public char[,] Sprite;
    public int Width { get => Sprite.GetLength(1) + Y; }
    public int Height { get => Sprite.GetLength(0) + X; }
    public Drawable(int x, int y)
    {
        this.x = x;
        this.y = y;
        Sprite = loadSprite();
    }
    protected abstract char[,] loadSprite();
}
