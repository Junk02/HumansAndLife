using System;

namespace HumansAndLife_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map(Console.WindowHeight - 1, Console.WindowWidth / 2, 10);
            map.MakeTrees(100);
            map.DrawMap();
        }
    }
}
