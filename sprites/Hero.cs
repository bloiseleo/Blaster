using Blaster.ui;
using System.Text.RegularExpressions;

namespace Blaster.sprites;

internal class Hero(int x, int y) : Drawable(x, y)
{
    protected override char[,] loadSprite()
    {
        var reader = new SpriteReader();
        return reader.Read("./../../../sprites/hero.txt");
    }
}
