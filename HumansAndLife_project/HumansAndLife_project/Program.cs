using System;

namespace HumansAndLife_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map(10, 20, 10);
            map.MakeTrees(10);
            map.DrawMap();
        }
    }
}
