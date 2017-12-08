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
        public static string sign_player = "C";

        public static IReadOnlyList<string> unable_to_walk_thru_signs = new List<string>
        {
            sign_wall_top_n_bottom,
            sign_wall_left_n_right,
            sign_wall_corner_top_left,
            sign_wall_corner_top_right,
            sign_wall_corner_bottom_left,
            sign_wall_corner_bottom_right,
            sign_blocked_way,
            sign_player
        };

        public enum Direction
        {
            North,
            South,
            East,
            West,
            NorthEast,
            NorthWest,
            SouthEast,
            SouthWest
        }

        public static List<string> warnings = new List<string>();

        public static void showWarnings()
        {
            foreach (string warning in warnings)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(warning);
            }
            warnings.Clear();
        }
        public static readonly ConsoleKey[] player2Keys =
        {
              ConsoleKey.Q, ConsoleKey.W, ConsoleKey.E,
              ConsoleKey.A,               ConsoleKey.D,
              ConsoleKey.Z, ConsoleKey.S, ConsoleKey.C
        };

        // todo
        public static readonly ConsoleKey[] player1Keys =
        {
            ConsoleKey.NumPad7, ConsoleKey.NumPad8, ConsoleKey.NumPad9,
            ConsoleKey.NumPad6,                     ConsoleKey.NumPad4,
            ConsoleKey.NumPad3, ConsoleKey.NumPad3, ConsoleKey.NumPad1,
            ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow,
            ConsoleKey.RightArrow
        };
    }
}
