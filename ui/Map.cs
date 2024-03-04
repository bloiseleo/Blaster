using System.Text;

namespace Blaster.ui;

internal class Map
{
    private int lines;
    private int columns;
    private char[,] map;
    public int Lines { get; }
    public int Columns { get; }
    public Map(int lines, int columns)
    {
        if (lines <= 0 || columns <= 0)
        {
            throw new IndexOutOfRangeException("lines or columns must be bigger than 0");
        }
        Lines = lines;
        Columns = columns;
        this.lines = lines;
        this.columns = columns;
        createMap();
    }
    public void Replace(Drawable drawable, int x, int y)
    {
        char[,] sprite = drawable.Sprite;
        int width = sprite.GetLength(1);
        int height = sprite.GetLength(0);
        for (int i = x; i < x + height; i++)
        {
            for (int j = y; j < y + width; j++)
            {
                map[i, j] = ' ';
            }
        }
        FullfillInMap(drawable.X, drawable.X + height, drawable.Y, drawable.Y + width, sprite);
    }
    public void FullfillInMap(int fromLine, int toLine, int fromColumn, int toColumn, char[,] charmap)
    {
        int c = 0, l = 0;
        for (int i = fromLine; i < toLine; i++)
        {
            for (int j = fromColumn; j < toColumn; j++)
            {
                map[i, j] = charmap[l, c++];
            }
            l++;
            c = 0;
        }
    }
    public void Draw(Drawable obj)
    {
        char[,] sprite = obj.Sprite;
        int width = sprite.GetLength(1);
        int height = sprite.GetLength(0);
        FullfillInMap(obj.X, obj.X + height, obj.Y, obj.Y + width, sprite);
    }
    private void createMap()
    {
        map = new char[lines, columns];
        Console.WriteLine(map.GetLength(0));
        Console.WriteLine(map.GetLength(1));
        Clear();
    }
    public void Clear()
    {
        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                map[i, j] = ' ';
            }
        }
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                sb.Append(map[i, j]);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
