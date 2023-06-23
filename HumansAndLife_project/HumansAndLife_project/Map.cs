
using System;
using System.Collections.Concurrent;

namespace HumansAndLife_project
{
    internal class Map
    {
        public int x_size, y_size, world_seed;
        Random rand;
        public Terrain[,] map;

        public Map(int x, int y, int seed)
        {
            x_size = x;
            y_size = y;
            world_seed = seed;
            rand = new Random(world_seed);
            map = new Terrain[x_size, y_size];

            for (int i = 0; i < x_size; i++)
                for (int j = 0; j < y_size; j++)
                    map[i, j] = new Terrain();
        }

        public void MakeTrees(int kol)
        {
            for (int i = 0; i < kol; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(0, x_size);
                    y = rand.Next(0, y_size);
                }
                while (map[x, y].current_obj != null);

                map[x, y].current_obj = new Tree();
            }
        }

        public void DrawMap()
        {
            for (int i = 0; i < x_size; i++)
            {
                for (int j = 0; j < y_size; j++)
                {
                    if (map[i, j].current_obj == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write('*');
                    }
                    else
                    {
                        Console.ForegroundColor = map[i, j].current_obj.color;
                        Console.Write(map[i, j].current_obj.symb);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
    }
}
