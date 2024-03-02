using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blaster.sprites
{
    internal class SpriteReader
    {
        private int[] extractCoords(string line)
        {
            var re = new Regex(@"\d+");
            var m = re.Matches(line);

            if (m.Count() != 2)
            {
                throw new Exception("Invalid sprite!");
            }

            return [int.Parse(m.First().Value), int.Parse(m.Last().Value)];
        }
        public char[,] Read(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            
            var line = streamReader.ReadLine();
            
            if (line == null)
            {
                throw new Exception("Invalid sprite!");
            }

            int[] coords = extractCoords(line);

            int lines = coords[0];
            int columns = coords[1];

            char[,] sprite = new char[lines, columns];
            int c = 0;
            int l = 0;
            
            while (line != null)
            {
                line = streamReader.ReadLine();
                if (line == null)
                {
                    continue;
                }
                if (line.Length > columns)
                {
                    throw new Exception("Invalid Sprite! Line length must be lesser or equal to defined in the header");
                }
                foreach (char s in line)
                {
                    sprite[l, c++] = s;
                }
                while (c < columns)
                {
                    sprite[l, c++] = ' ';
                }
                c = 0; l++;
            }
            streamReader.Close();
            return sprite;
        }
    }
}
