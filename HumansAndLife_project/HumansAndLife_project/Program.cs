using System;
using System.Threading;

namespace HumansAndLife_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;

            Random rand = new Random();

            Console.Write("Введите сид мира, или введите -1 чтобы он сгенерировался случайно: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Map map;

            if (a == -1) map = new Map(1000, 1000, rand.Next(0, 1000));

            else map = new Map(Console.BufferHeight - 1, Console.BufferWidth / 2, a);

            Player player = new Player(1, 1);

            map.MakeRiver();
            map.MakeTrees(10000);

            //Console.SetCursorPosition(Console.BufferWidth / 2 + 1, 0);
            //Console.WriteLine("World seed: " + map.world_seed.ToString());
            //Console.SetCursorPosition(0, Console.BufferHeight - 1);

            ConsoleKeyInfo key;

            Console.CursorVisible = false;

            while (true)
            {
                map.DrawMap(player);
                Thread.Sleep(50);
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.W && player.cam_x > 0) player.cam_x--;
                else if (key.Key == ConsoleKey.A && player.cam_y > 0) player.cam_y--;
                else if (key.Key == ConsoleKey.S && player.cam_x < map.x_size - 1) player.cam_x++;
                else if (key.Key == ConsoleKey.D && player.cam_y < map.y_size - 1) player.cam_y++;
            }
        }
    }
}
