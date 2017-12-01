using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customly_Edited_Pacman
{
    class Game
    {

        // hardcoding is the way to go :>

        public static string sign_point = "+";
        public static string sign_wall_top_n_bottom = "═";
        public static string sign_wall_left_n_right = "║";
        public static string sign_wall_corner_top_left = "╔";
        public static string sign_wall_corner_top_right = "╗";
        public static string sign_wall_corner_bottom_left = "╚";
        public static string sign_wall_corner_bottom_right = "╝";
        public static string sign_blocked_way = "█";

        public static IReadOnlyList<string> signs = new List<string>
        {
            sign_wall_top_n_bottom,
            sign_wall_left_n_right,
            sign_wall_corner_top_left,
            sign_wall_corner_top_right,
            sign_wall_corner_bottom_left,
            sign_wall_corner_bottom_right,
            sign_blocked_way
        };


        public enum Direction

        {
            North,
            South,
            East,
            West
        }

        public static List<string> warnings = new List<string>();

        public static void ShowWarnings()
        {
            foreach (string warning in warnings)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(warning);
            }
            warnings.Clear();
        }
        public static readonly ConsoleKey[] player1Keys =
        {
              ConsoleKey.Q, ConsoleKey.W, ConsoleKey.E,
              ConsoleKey.A,               ConsoleKey.D,
              ConsoleKey.Z, ConsoleKey.S, ConsoleKey.C
        };
        public static readonly ConsoleKey[] player2Keys =
        {
              ConsoleKey.NumPad7, ConsoleKey.NumPad8, ConsoleKey.NumPad9,
              ConsoleKey.NumPad6,                     ConsoleKey.NumPad4,
              ConsoleKey.NumPad3, ConsoleKey.NumPad3, ConsoleKey.NumPad1
        };
    }
}
