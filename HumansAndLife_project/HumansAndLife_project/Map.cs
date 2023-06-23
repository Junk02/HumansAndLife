
using System;
using System.Collections.Concurrent;

namespace HumansAndLife_project
{
    internal class Map
    {
        public int x_size, y_size;
        public Terrain[,] map;

        public Map(int x, int y)
        {
            x_size = x;
            y_size = y;
            map = new Terrain[x_size, y_size];

            for (int i = 0; i < x_size; i++)
                for (int j = 0; j < y_size; j++)
                    map[i, j] = new Terrain();
        }

        public void DrawMap()
        {
            for (int i = 0; i < x_size; i++)
            {
                for (int j = 0; j < y_size; j++)
                {
                    if (map[i, j].current_obj == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('^');
                    }
                    else
                    {

                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
    }
}
