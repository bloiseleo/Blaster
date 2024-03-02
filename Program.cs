using System.Text;

namespace Blaster;

internal class Program
{
    static void Main(string[] args)
    {
        var map = new Map(10, 100);
        var hero = new Hero(0, 0);
        map.Draw(hero);
        Console.WriteLine(map);
    }
}
