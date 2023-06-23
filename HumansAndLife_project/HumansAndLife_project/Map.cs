
using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

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

        public void MakeRiver()
        {
            int side = rand.Next(1, 3);
            int x = 0, y = 0;

            if (side == 1)
            {
                y = rand.Next(3, y_size - 3);
                x = 0;

                if (map[x, y].IsFree()) map[x, y].current_obj = new River();

                while (x < x_size - 1)
                {
                    if (rand.Next(1, 3) == 1)
                        if (map[x, y - 1].IsFree()) map[x, y - 1].current_obj = new River();
                    if (rand.Next(1, 3) == 1)
                        if (map[x, y + 1].IsFree()) map[x, y + 1].current_obj = new River();

                    x++;
                    if (map[x, y].IsFree()) map[x, y].current_obj = new River();

                    if (rand.Next(1, 5) == 1)
                    {
                        int expansion_side = rand.Next(1, 3);
                        if (expansion_side == 1 && y > 1) y--;
                        else if (expansion_side == 2 && y < y_size - 2) y++;
                    }
                }
            }

            else if (side == 2)
            {
                y = 0;
                x = rand.Next(3, x_size - 3);

                if (map[x, y].IsFree()) map[x, y].current_obj = new River();

                while (y < y_size - 1)
                {
                    if (rand.Next(1, 3) == 1)
                        if (map[x - 1, y].IsFree()) map[x - 1, y].current_obj = new River();
                    if (rand.Next(1, 3) == 1)
                        if (map[x + 1, y].IsFree()) map[x + 1, y].current_obj = new River();

                    y++;
                    if (map[x, y].IsFree()) map[x, y].current_obj = new River();

                    if (rand.Next(1, 5) == 1)
                    {
                        int expansion_side = rand.Next(1, 3);
                        if (expansion_side == 1 && x > 1) x--;
                        else if (expansion_side == 2 && x < x_size - 2) x++;
                    }
                }
            }

            for (int i = 1; i < x_size - 1; i++)
                for (int j = 1; j < y_size - 1; j++)
                {
                    int kol = 0;
                    if (!map[i - 1, j].IsFree() && map[i - 1, j].current_obj.GetType().Name == "River") kol++;
                    if (!map[i + 1, j].IsFree() && map[i + 1, j].current_obj.GetType().Name == "River") kol++;
                    if (!map[i, j - 1].IsFree() && map[i, j - 1].current_obj.GetType().Name == "River") kol++;
                    if (!map[i, j + 1].IsFree() && map[i, j + 1].current_obj.GetType().Name == "River") kol++;

                    if (kol > 2) map[i, j].current_obj = new River();
                }
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
                while (!map[x, y].IsFree());

                map[x, y].current_obj = new Tree();
            }
        }

        public void DrawMap()
        {
            for (int i = 0; i < x_size; i++)
            {
                for (int j = 0; j < y_size; j++)
                {
                    if (map[i, j].IsFree())
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
