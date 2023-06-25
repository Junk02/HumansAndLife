using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HumansAndLife_project
{
    internal class Player
    {
        public int cam_x, cam_y, cam_view = 10;

        public Player(int x, int y)
        {
            cam_x = x;
            cam_y = y;
        }
    }
}
