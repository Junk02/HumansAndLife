using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumansAndLife_project
{
    internal class Game
    {
        Map map;

        public Game(int x, int y, int seed)
        {
            map = new Map(x, y, seed);
        }
    }
}
