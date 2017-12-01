using System;
using static Customly_Edited_Pacman.Program;
namespace Customly_Edited_Pacman
{
    class Movement
    {
        public static bool PlayerMovement(ConsoleKey key)
        {
            int new_x = 0;
            int new_y = 0;
            int currentX = player.getCoorsX();
            int currentY = player.getCoorsY();
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    new_x = currentX -1;
                    new_y = currentY;
                    break;
                case ConsoleKey.DownArrow:
                    new_x = currentX + 1;
                    new_y = currentY;
                    break;
                case ConsoleKey.RightArrow:
                    new_x = currentX;
                    new_y = currentY + 1;
                    break;
                case ConsoleKey.LeftArrow:
                    new_x = currentX;
                    new_y = currentY - 1;
                    break;
                case ConsoleKey.Home:
                    new_x = currentX - 1;
                    new_y = currentY - 1;
                    break;
                case ConsoleKey.PageUp:
                    new_x = currentX -1;
                    new_y = currentY +1;
                    break;
                case ConsoleKey.End:
                    new_x = currentX +1;
                    new_y = currentY - 1;
                    break;
                case ConsoleKey.PageDown:
                    new_x = currentX +1;
                    new_y = currentY + 1;
                    break;
                case ConsoleKey.NumPad5:
                    return false;
                default:
                    Console.WriteLine(@"Use < ^ > \/ arrows");
                    break;
            }
            if (arr[new_x, new_y]=="O")
            {
                max_points_on_current_maze--;
            }
            if (arr[new_x, new_y] != "X")
            {
                arr[currentX, currentY] = " ";
                arr[new_x, new_y] = "C";
                player.setCoords(new_x, new_y);
            }
            return true;
        }
    }
}
