using Blaster.sprites;
using Blaster.ui;
using System.Text.RegularExpressions;

namespace Blaster;

internal class Hero(int x, int y): Drawable(x, y)
{
    protected override char[,] loadSprite()
    {
        var reader = new SpriteReader();
        return reader.Read("./../../../sprites/hero.txt");
    }
}
