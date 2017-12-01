using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customly_Edited_Pacman
{
    class Map
    {
        public static Int32 amount_of_points_on_map(string[,] arr)
        {
            int height = arr.GetLength(0);
            int width = arr.GetLength(1);
            int count = 0;
            for (int i=0; i<height; i++)
            {
                for (int j=0; j<width; j++)
                {
                    if (arr[i,j] == "O")
                    {
                        count++;
                    }
                }
            }
            return count-1; // because spawn_place takes one point
        }
        public static string[,] create_2D_array(int height, int width)
        {
            string[,] arr = new string[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    arr[i, j] = "O";
                }
            }
            return arr;
        }

        public static bool BlockAintBlocked(int x, int y, string[,] arr)
        {
            List<int> x_coords = new List<int>(8);
            List<int> y_coords = new List<int>(8);
            #region hardcoding
            x_coords.Add(-1);
            y_coords.Add(0);

            x_coords.Add(-1);
            y_coords.Add(1);

            x_coords.Add(0);
            y_coords.Add(1);

            x_coords.Add(1);
            y_coords.Add(1);

            x_coords.Add(1);
            y_coords.Add(0);

            x_coords.Add(1);
            y_coords.Add(-1);

            x_coords.Add(0);
            y_coords.Add(-1);

            x_coords.Add(-1);
            y_coords.Add(-1);
            #endregion
            int height = arr.GetLength(0);
            int width = arr.GetLength(1);

            int amountOfExits = 0;
            for (int i = 0; i < x_coords.Count; i++)
            {
                try
                {
                    if (x + x_coords[i] > 0 && x + x_coords[i] < height && y + y_coords[i] >0 && y + y_coords[i] < width)
                    {
                        if (arr[x + x_coords[i], y + y_coords[i]] == "O")
                        {
                            amountOfExits++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("_______________");
                    Console.WriteLine($"Ex: {ex.Message}");
                    Console.WriteLine(i);
                    Console.WriteLine(x_coords[i]);
                    Console.WriteLine(y_coords[i]);
                    Console.WriteLine("_______________");
                }
            }
            return amountOfExits >= 2;
        }
        public static string[,] CreateMaze(string[,] arr)
        {
            Random rnd = new Random();
            int height = arr.GetLength(0);
            int width = arr.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i != 0 && i != height - 1 && j != 0 && j != width - 1)
                    {
                        if (BlockAintBlocked(i, j, arr))
                        {
                            int temp = rnd.Next(3);
                            if (temp == 2)
                            {
                                arr[i, j] = "X";
                            }
                            else
                            {
                                arr[i, j] = "O";
                            }
                        }
                        else
                        {
                            arr[i, j] = "O";
                        }
                    }
                }
            }
            return arr;
        }

        public static void ShowMap(string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(arr[i, j] + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(arr[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        public static string[,] createBorder(string[,] arr)
        {
            int height = arr.GetLength(0);
            int width = arr.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                    {
                        arr[i, j] = "X";
                    }
                }
            }
            return arr;
        }
    }
}
