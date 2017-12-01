using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customly_Edited_Pacman
{
    class Game
    {
        public enum Direction
        {
            North,
            South,
            East,
            West
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
