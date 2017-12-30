using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Customly_Edited_Pacman.Core;

namespace Customly_Edited_Pacman
{
    class Game
    {
        // hardcoding is the way to go :>

        public const string sign_point = "+";
        public const string sign_wall_top_n_bottom = "═";
        public const string sign_wall_left_n_right = "║";
        public const string sign_wall_corner_top_left = "╔";
        public const string sign_wall_corner_top_right = "╗";
        public const string sign_wall_corner_bottom_left = "╚";
        public const string sign_wall_corner_bottom_right = "╝";
        public const string sign_blocked_way = "█";
        public const string sign_player = "C";

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
            SouthWest,
            None
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

        public static /*async*/ void whoWon(int height, int width)
        {
            if (Core.player.getScore() == 100 || Core.player2.getScore() == 100)
            {
                Console.Clear();
                string playerName = (player.getScore() == 100) ? "player1" : "player2";
                Console.WriteLine('\t' + "Winner!");
                Console.WriteLine('\t' + playerName + ": gg easy");
                //  await Task.Delay(3500);
                Thread.Sleep(3500); // actually sleep should be used cuz task delay is async and "goes ahead" and aint waiting
                resetGame(height, width);


                while (Console.KeyAvailable) // bit level hacking that prevents spamming move + direction keys during 
                                             // displaying winner's name
                {
                    Console.ReadKey(true);
                }
                Console.WriteLine("Press button to continue");
            }
        }

        public static void resetGame(int height, int width)
        {
            resetMap(height,width);
            player.setScore(0);
            player2.setScore(0);
        }
        public static void resetMap(int height, int width)
        {
            _Map =Map. createMaze(_Map);
            int initial_x = height / 2;
            int initial_y = width / 2;

            player.setCoords(initial_x, initial_y);
            player2.setCoords(initial_x, initial_y);
            _Map[initial_x, initial_y] = " ";
        }
        public static void showGameInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Use ESCAPE button to reset map if some points aint really accessible");
            Console.WriteLine("Player1's score: " + player.getScore());
            Console.WriteLine("Player2's score: " + player2.getScore());
            Console.WriteLine(max_points_on_current_maze);
        }
        public static readonly ConsoleKey[] player2Keys =
        {
              ConsoleKey.Q, ConsoleKey.W, ConsoleKey.E,
              ConsoleKey.A,               ConsoleKey.D,
              ConsoleKey.Z, ConsoleKey.S, ConsoleKey.C
        };

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
