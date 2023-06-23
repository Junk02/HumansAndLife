using System;

namespace HumansAndLife_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;

            Random rand = new Random();

            Console.Write("Введите сид мира, или введите -1 чтобы он сгенерировался случайно: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Map map;

            if (a == -1) map = new Map(Console.BufferHeight - 1, Console.BufferWidth / 2, rand.Next(0, 1000));

            else map = new Map(Console.BufferHeight - 1, Console.BufferWidth / 2, a);

            map.MakeRiver();
            map.MakeTrees(100);
            map.DrawMap();

            Console.SetCursorPosition(Console.BufferWidth / 2 + 1, 0);
            Console.WriteLine("World seed: " + map.world_seed.ToString());
            Console.SetCursorPosition(0, Console.BufferHeight - 1);
        }
    }
}
