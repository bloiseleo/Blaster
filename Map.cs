using Blaster.ui;
using System.Text;

namespace Blaster;

internal class Map
{
    private int lines;
    private int columns;
    private char[,] map;
    public Map(int lines, int columns)
    {
        if (lines <= 0 || columns <= 0)
        {
            throw new IndexOutOfRangeException("lines or columns must be bigger than 0");
        }
        this.lines = lines;
        this.columns = columns;
        this.createMap();
    }
    public void Draw(Drawable obj)
    {
        char[,] sprite = obj.Sprite;
        int width = sprite.GetLength(1);
        int height = sprite.GetLength(0);
        int x = obj.X;
        int y = obj.Y;
        int c = 0;
        int d = 0;
        for(int i = x; i < (x + height); i++)
        {
            for(int j = y; j < (y + width); j++)
            {
                map[i,j] = sprite[d, c++];
            }
            d++;
            c = 0;
        }
    }
    private void createMap()
    {
        map = new char[lines, columns];
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
        for(int i = 0; i < lines; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                sb.Append(map[i,j]);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
